using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.WebApp.Controllers;
using NUnit.Framework;

namespace Budget.UnitTests.WebApp.Controllers
{
    [TestFixture]
    class BaseControllerTests
    {
        [Test]
        public void AllControllersShouldDeriveFromBaseController()
        {
            Type baseControllerType = typeof(BaseController);
            var controllers = baseControllerType
                .Assembly
                .GetTypes()
                .Where(t => !t.FullName.Contains("T4MVC") &&
                            t.Name.EndsWith("Controller") &&
                            !baseControllerType.IsAssignableFrom(t));

            CollectionAssert.IsEmpty(controllers, string.Join(" ", controllers.Select(c => c.FullName)));
        }
    }
}
