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

namespace Budget.UnitTests.WebApp
{
    [TestFixture]
    class DependencyResolutionTests
    {
        [Test]
        public void StructureMapInternalTest()
        {
            IoC.EnsureConfigIsValid();
        }

        [Test]
        public void ShouldInstantiateAllControllers()
        {
            // Arrange
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
