using System;
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
            RouteConfig.RegisterRoutes(this.routes);

            this.configuration = new HttpConfiguration(this.routes);
            this.controllerSelector = new DefaultHttpControllerSelector(this.configuration);
            this.actionSelector = new ApiControllerActionSelector();
        }

        [Test]
        [TestCaseSource("Generate")]
        public void UrlMatchControllerAndAction(Scenario scenario)
        {
            HttpRequestMessage request = new HttpRequestMessage(scenario.HttpMethod, scenario.Url);
            IHttpRouteData routeData = this.routes.GetRouteData(request);
            request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;

            HttpControllerContext controllerContext = new HttpControllerContext(this.configuration, routeData, request);
            controllerContext.ControllerDescriptor = this.controllerSelector.SelectController(request);

            Type selectedController = controllerContext.ControllerDescriptor.ControllerType;
            string actionName = this.actionSelector.SelectAction(controllerContext).ActionName;

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
                Url = @"http://nonexisting/api/Receipt/",
                HttpMethod = HttpMethod.Get,
                ExpectedController = typeof(ReceiptController),
                ExpectedAction = MethodName((ReceiptController c) => c.GetReceipts()),
            };

            yield return new Scenario
            {
                Url = @"http://nonexisting/api/Receipt/2",
                HttpMethod = HttpMethod.Get,
                ExpectedController = typeof(ReceiptController),
                ExpectedAction = MethodName((ReceiptController c) => c.GetReceipt(0)),
            };

            yield return new Scenario
            {
                Url = @"http://nonexisting/api/Receipt/null/null",
                HttpMethod = HttpMethod.Get,
                ExpectedController = typeof(ReceiptController),
                ExpectedAction = MethodName((ReceiptController c) => c.GetReceiptsFromDateRange(null, null)),
            };

            yield return new Scenario
            {
                Url = @"http://nonexisting/api/Receipt/null/20160505",
                HttpMethod = HttpMethod.Get,
                ExpectedController = typeof(ReceiptController),
                ExpectedAction = MethodName((ReceiptController c) => c.GetReceiptsFromDateRange(null, null)),
            };

            yield return new Scenario
            {
                Url = @"http://nonexisting/api/Receipt/20160505/null",
                HttpMethod = HttpMethod.Get,
                ExpectedController = typeof(ReceiptController),
                ExpectedAction = MethodName((ReceiptController c) => c.GetReceiptsFromDateRange(null, null)),
            };

            yield return new Scenario
            {
                Url = @"http://nonexisting/api/Receipt/20160505/20160505",
                HttpMethod = HttpMethod.Get,
                ExpectedController = typeof(ReceiptController),
                ExpectedAction = MethodName((ReceiptController c) => c.GetReceiptsFromDateRange(null, null)),
            };
        }
    }
}
