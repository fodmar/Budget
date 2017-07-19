using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Budget.WebApp.Controllers;
using Budget.WebApp.DependencyResolution;
using Budget.WebApp;
using System.Web.Mvc;
using System.Web;
using System.Web.Hosting;

namespace Budget.UnitTests.WebApp
{
    [TestFixture]
    class WebAppDependencyResolutionTests
    {
        [Test]
        public void StructureMapInternalTestWebApp()
        {
            IoC.EnsureConfigIsValid();
        }

        [Test]
        public void ShouldInstantiateAllControllersWebApp()
        {
            // Arrange
            SimpleWorkerRequest request = new SimpleWorkerRequest(string.Empty, string.Empty, string.Empty, null, null);
            HttpContext.Current = new HttpContext(request);

            Type baseType = typeof(BaseController);
            var toCreate = baseType.Assembly
                                   .GetTypes()
                                   .Where(t => t.IsSubclassOf(baseType));

            // Act
            DependencyResolutionConfig.InitializeDependencyResolution();
            foreach (Type controllerType in toCreate)
            {
                DependencyResolver.Current.GetService(controllerType);
            }
        }
    }
}
