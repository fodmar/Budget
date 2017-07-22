using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.BusinessLogic.UserManagement;
using Budget.ObjectModel;
using Budget.WebApp.Authentication;
using Budget.WebApp.Models;
using Budget.WebApp.Utils;
using NUnit.Framework;
using Rhino.Mocks;

namespace Budget.UnitTests.WebApp
{
    [TestFixture]
    class AuthenticatorTests
    {
        [Test]
        public async void AuthenticatorLoginShouldLoginWhenServiceReturnsUser()
        {
            User user = new User();
            user.Id = 1;
            user.Name = "a";

            LoginAttempt attempt = new LoginAttempt(user);

            LoginModel model = new LoginModel();
            model.Login = "b";
            model.Password = "c";

            ILoginService service = MockRepository.GenerateStub<ILoginService>();
            ISessionHelper session = MockRepository.GenerateStub<ISessionHelper>();
            IFormsAuthentication forms = MockRepository.GenerateStub<IFormsAuthentication>();

            service.Stub(s => s.Login(model.Login, model.Password)).Return(Task<LoginAttempt>.FromResult(attempt));

            Authenticator authenticator = new Authenticator(service, session, forms);
            bool result = await authenticator.Login(model);

            Assert.IsTrue(result);
            service.AssertWasCalled(s => s.Login(model.Login, model.Password));
            Assert.AreEqual(session.UserId, user.Id);
            forms.AssertWasCalled(f => f.SetAuthCookie(user.Id.ToString(), true));
        }

        [Test]
        public async void AuthenticatorLoginShouldNotLoginWhenServiceReturnsNull()
        {
            User user = null;

            LoginAttempt attempt = new LoginAttempt(user);

            LoginModel model = new LoginModel();
            model.Login = "b";
            model.Password = "c";

            ILoginService service = MockRepository.GenerateStub<ILoginService>();
            ISessionHelper session = MockRepository.GenerateStub<ISessionHelper>();
            IFormsAuthentication forms = MockRepository.GenerateStub<IFormsAuthentication>();

            service.Stub(s => s.Login(model.Login, model.Password)).Return(Task<LoginAttempt>.FromResult(attempt));

            Authenticator authenticator = new Authenticator(service, session, forms);
            bool result = await authenticator.Login(model);

            Assert.IsFalse(result);
            service.AssertWasCalled(s => s.Login(model.Login, model.Password));
            session.AssertWasNotCalled(s => s.UserId);
            forms.AssertWasNotCalled(f => f.SetAuthCookie(Arg<string>.Is.Anything, Arg<bool>.Is.Anything));
        }

        [Test]
        public void AuthenticationLogoutShouldClearSessionAndSingout()
        {
            ISessionHelper session = MockRepository.GenerateStub<ISessionHelper>();
            IFormsAuthentication forms = MockRepository.GenerateStub<IFormsAuthentication>();

            Authenticator authenticator = new Authenticator(null, session, forms);
            authenticator.Logout();

            session.AssertWasCalled(s => s.Clear());
            forms.AssertWasCalled(f => f.SignOut());
        }
    }
}
