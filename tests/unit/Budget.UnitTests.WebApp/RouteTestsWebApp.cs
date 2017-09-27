using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Budget.WebApp;

namespace Budget.UnitTests.WebApp
{
    [TestFixture]
    class RouteTestsWebApp
    {
        [Test]
        public void TestWebAppRoutes()
        {
            TestRoute("~/", "GET", MVC.Overview.Name, MVC.Overview.ActionNames.Overview);
            TestRoute("~/Overview", "GET", MVC.Overview.Name, MVC.Overview.ActionNames.Overview);
            TestRoute("~/Overview/Overview", "GET", MVC.Overview.Name, MVC.Overview.ActionNames.Overview);
            TestRoute("~/Overview/GetReceipts/start=2017-08-28&end=2017-10-09", "GET", MVC.Overview.Name, MVC.Overview.ActionNames.GetReceipts);
            TestRoute("~/Login/Login", "GET", MVC.Login.Name, MVC.Login.ActionNames.Login);
            TestRoute("~/Login/Login", "POST", MVC.Login.Name, MVC.Login.ActionNames.Login);
            TestRoute("~/Login/Logout", "GET", MVC.Login.Name, MVC.Login.ActionNames.Logout);
            TestRoute("~/Overview/SaveReceipt", "POST", MVC.Overview.Name, MVC.Overview.ActionNames.SaveReceipt);
            TestRoute("~/Product/Index", "GET", MVC.Product.Name, MVC.Product.ActionNames.Index);
            TestRoute("~/Product/GetAll", "GET", MVC.Product.Name, MVC.Product.ActionNames.GetAll);
            TestRoute("~/Product/Add", "PUT", MVC.Product.Name, MVC.Product.ActionNames.Add);
            TestRoute("~/Product/Delete", "DELETE", MVC.Product.Name, MVC.Product.ActionNames.Delete);
            TestRoute("~/Product/Update", "POST", MVC.Product.Name, MVC.Product.ActionNames.Update);
        }

        private HttpContextBase CreateHttpContext(string url, string method)
        {
            HttpRequestBase request = MockRepository.GenerateStub<HttpRequestBase>();
            request.Stub(s => s.AppRelativeCurrentExecutionFilePath).Return(url);
            request.Stub(s => s.HttpMethod).Return(method);

            HttpResponseBase response = MockRepository.GenerateStub<HttpResponseBase>();
            response.Stub(s => s.ApplyAppPathModifier(Arg<string>.Is.Anything)).Return(url);

            HttpContextBase context = MockRepository.GenerateStub<HttpContextBase>();
            context.Stub(s => s.Request).Return(request);
            context.Stub(s => s.Response).Return(response);

            return context;
        }

        private void TestRoute(string url, string method, string expectedController, string expectedAction)
        {
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            RouteData routeData = routes.GetRouteData(this.CreateHttpContext(url, method));

            Assert.IsNotNull(routeData, url);
            Assert.AreEqual(expectedController, routeData.Values["controller"], url);
            Assert.AreEqual(expectedAction, routeData.Values["action"], url);
        }
    }
}
