using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using NUnit.Framework;
using Budget.WebApi;
using System.Web.Http.Dependencies;
using Budget.WebApi.Controllers;
using System.Web;
using System.Web.Hosting;
using Rhino.Mocks;

namespace Budget.UnitTests.WebApi
{
    [TestFixture]
    class DependencyResolutionTests
    {
        [Test]
        public void ShouldInstantiateAllControllers()
        {
            // Arrange
            SimpleWorkerRequest request = new SimpleWorkerRequest(string.Empty, string.Empty, string.Empty, null, null);
            HttpContext.Current = new HttpContext(request);
            HttpConfiguration httpConfig = new HttpConfiguration();

            Type baseType = typeof(BaseController);
            var toCreate = baseType.Assembly
                                   .GetTypes()
                                   .Where(t => t.IsSubclassOf(baseType));

            // Act
            WebApiConfig.InitializeDependencyResolution(httpConfig);
            foreach (Type controllerType in toCreate)
            {
                httpConfig.DependencyResolver.GetService(controllerType);
            }
        }
    }
}
