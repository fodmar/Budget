using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.WebApp.Controllers;
using NUnit.Framework;
using System.Web.Mvc;
using Budget.WebApp.Models;
using Budget.WebApp.Authentication;
using Rhino.Mocks;

namespace Budget.UnitTests.WebApp.Controllers
{
    [TestFixture]
    class LoginControllerTests
    {
        [Test]
        public void ShouldRememberReturnUrlWhenGiven()
        {
            string returnUrl = "lala";
            LoginController controller = new LoginController(null);

            ViewResult result = controller.Login(returnUrl) as ViewResult;
            LoginModel model = result.Model as LoginModel;

            Assert.AreEqual(returnUrl, model.ReturnUrl);
        }

        [Test]
        public async void ShouldRedirectBackWhenCorrectLogin()
        {
            LoginModel model = new LoginModel();
            model.ReturnUrl = "a";
            model.Login = "b";
            model.Password = "c";

            IAuthenticator authenticator = MockRepository.GenerateStub<IAuthenticator>();
            authenticator.Stub(s => s.Login(model)).Return(Task<bool>.FromResult(true));

            UrlHelper urlHelper = MockRepository.GenerateStub<UrlHelper>();
            urlHelper.Stub(s => s.Content(model.ReturnUrl)).Return(model.ReturnUrl);

            LoginController controller = new LoginController(authenticator);
            controller.Url = urlHelper;

            ActionResult result = await controller.Login(model);

            authenticator.AssertWasCalled(s => s.Login(model));
            RedirectResult redirect = result as RedirectResult;
            Assert.AreEqual(model.ReturnUrl, redirect.Url);
        }

        [Test]
        public async void ShouldReturnLoginViewWhenUncorrectLogin()
        {
            LoginModel model = new LoginModel();
            model.ReturnUrl = "a";
            model.Login = "b";
            model.Password = "c";

            IAuthenticator authenticator = MockRepository.GenerateStub<IAuthenticator>();
            authenticator.Stub(s => s.Login(model)).Return(Task<bool>.FromResult(false));

            LoginController controller = new LoginController(authenticator);
            ActionResult result = await controller.Login(model);

            authenticator.AssertWasCalled(s => s.Login(model));
            ViewResult view = result as ViewResult;
            Assert.IsNullOrEmpty(view.ViewName);
            Assert.IsNullOrEmpty(model.Password);
            Assert.IsFalse(controller.ModelState.IsValid);
        }

        [Test]
        public void ShouldCallAuthenticatorAndReturnLoginViewWhenLogoff()
        {
            IAuthenticator authenticator = MockRepository.GenerateStub<IAuthenticator>();
            LoginController controller = new LoginController(authenticator);

            ActionResult result = controller.Logout();

            authenticator.AssertWasCalled(a => a.Logout());
            RedirectToRouteResult redirect = result as RedirectToRouteResult;
            Assert.AreEqual(MVC.Login.Views.ViewNames.Login, redirect.RouteValues["action"]);
        }
    }
}
