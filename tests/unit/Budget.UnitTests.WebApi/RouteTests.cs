﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Budget.WebApi;
using Budget.WebApi.Controllers;
using NUnit.Framework;

namespace Budget.UnitTests.WebApi
{
    [TestFixture]
    class RouteTests
    {
        private HttpConfiguration configuration;
        private HttpRouteCollection routes;
        private DefaultHttpControllerSelector controllerSelector;
        private ApiControllerActionSelector actionSelector;

        public RouteTests()
        {
            this.routes = new HttpRouteCollection();
            this.configuration = new HttpConfiguration(this.routes);
            RouteConfig.RegisterRoutes(this.configuration);
            this.configuration.EnsureInitialized();

            this.controllerSelector = new DefaultHttpControllerSelector(this.configuration);
            this.actionSelector = new ApiControllerActionSelector();
        }

        [Test]
        [TestCaseSource("Generate")]
        public void UrlMatchControllerAndAction(Scenario scenario)
        {
            Type selectedController;
            string actionName;

            try
            {
                HttpRequestMessage request = new HttpRequestMessage(scenario.HttpMethod, scenario.Url);
                IHttpRouteData routeData = this.routes.GetRouteData(request);
                request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;

                HttpControllerContext controllerContext = new HttpControllerContext(this.configuration, routeData, request);
                controllerContext.ControllerDescriptor = this.controllerSelector.SelectController(request);

                selectedController = controllerContext.ControllerDescriptor.ControllerType;
                actionName = this.actionSelector.SelectAction(controllerContext).ActionName;
            }
            catch (Exception ex)
            {
                Exception exception = new Exception(string.Format("Fail for url {0}", scenario.Url), ex);
                throw exception;
            }

            Assert.AreEqual(scenario.ExpectedController, selectedController);
            Assert.AreEqual(scenario.ExpectedAction, actionName);
        }

        public class Scenario
        {
            public string Url { get; set; }
            public HttpMethod HttpMethod { get; set; }
            public Type ExpectedController { get; set; }
            public string ExpectedAction { get; set; }
        }

        private string MethodName<T, P>(Expression<Func<T, P>> expression)
        {
            MethodCallExpression method = expression.Body as MethodCallExpression;
            return method.Method.Name;
        }

        private IEnumerable<Scenario> Generate()
        {
            yield return new Scenario
            {
                Url = @"http://nonexisting/api/receipt/0",
                HttpMethod = HttpMethod.Get,
                ExpectedController = typeof(ReceiptController),
                ExpectedAction = MethodName((ReceiptController c) => c.GetReceipts(0)),
            };

            yield return new Scenario
            {
                Url = @"http://nonexisting/api/receipt/0/2",
                HttpMethod = HttpMethod.Get,
                ExpectedController = typeof(ReceiptController),
                ExpectedAction = MethodName((ReceiptController c) => c.GetReceipt(0, 0)),
            };

            yield return new Scenario
            {
                Url = @"http://nonexisting/api/receipt/0/null/null",
                HttpMethod = HttpMethod.Get,
                ExpectedController = typeof(ReceiptController),
                ExpectedAction = MethodName((ReceiptController c) => c.GetReceiptsFromDateRange(0, null, null)),
            };

            yield return new Scenario
            {
                Url = @"http://nonexisting/api/receipt/0/null/20160505",
                HttpMethod = HttpMethod.Get,
                ExpectedController = typeof(ReceiptController),
                ExpectedAction = MethodName((ReceiptController c) => c.GetReceiptsFromDateRange(0, null, null)),
            };

            yield return new Scenario
            {
                Url = @"http://nonexisting/api/receipt/0/20160505/null",
                HttpMethod = HttpMethod.Get,
                ExpectedController = typeof(ReceiptController),
                ExpectedAction = MethodName((ReceiptController c) => c.GetReceiptsFromDateRange(0, null, null)),
            };

            yield return new Scenario
            {
                Url = @"http://nonexisting/api/receipt/0/20160505/20160505",
                HttpMethod = HttpMethod.Get,
                ExpectedController = typeof(ReceiptController),
                ExpectedAction = MethodName((ReceiptController c) => c.GetReceiptsFromDateRange(0, null, null)),
            };

            yield return new Scenario
            {
                Url = @"http://nonexisting/api/receipt/",
                HttpMethod = HttpMethod.Put,
                ExpectedController = typeof(ReceiptController),
                ExpectedAction = MethodName((ReceiptController c) => c.SaveReceipt(null)),
            };

            yield return new Scenario
            {
                Url = @"http://nonexisting/api/user/a/a",
                HttpMethod = HttpMethod.Get,
                ExpectedController = typeof(UserController),
                ExpectedAction = MethodName((UserController c) => c.Find(null, null)),
            };

            yield return new Scenario
            {
                Url = @"http://nonexisting/api/product/",
                HttpMethod = HttpMethod.Get,
                ExpectedController = typeof(ProductController),
                ExpectedAction = MethodName((ProductController c) => c.GetAll()),
            };

            yield return new Scenario
            {
                Url = @"http://nonexisting/api/product/",
                HttpMethod = HttpMethod.Put,
                ExpectedController = typeof(ProductController),
                ExpectedAction = MethodName((ProductController c) => c.Insert(null)),
            };

            yield return new Scenario
            {
                Url = @"http://nonexisting/api/product/",
                HttpMethod = HttpMethod.Post,
                ExpectedController = typeof(ProductController),
                ExpectedAction = MethodName((ProductController c) => c.Update(null)),
            };

            yield return new Scenario
            {
                Url = @"http://nonexisting/api/product/123",
                HttpMethod = HttpMethod.Delete,
                ExpectedController = typeof(ProductController),
                ExpectedAction = MethodName((ProductController c) => c.Delete(0)),
            };
        }
    }
}
