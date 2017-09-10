using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;
using Budget.WebApp.Extensions;

namespace Budget.UnitTests.WebApp
{
    [TestFixture]
    class ModelStateExtensionsTests
    {
        [Test]
        public void PropertiesErrors()
        {
            ModelStateDictionary modelStateDictionary = new ModelStateDictionary();

            modelStateDictionary.AddModelError("test", "first");
            modelStateDictionary.AddModelError("test", "second");
            modelStateDictionary.AddModelError("test", "third");
            modelStateDictionary.AddModelError("a", "a");
            modelStateDictionary.AddModelError("b", "b");
            modelStateDictionary.AddModelError("b", new ArgumentException("b exception"));
            modelStateDictionary.AddModelError("c", new ArgumentException("c exception"));

            Dictionary<string, string[]> result = modelStateDictionary.PropertiesErrors();

            Assert.AreEqual(4, result.Count);
            Assert.That(result.ContainsKey("test"));
            Assert.That(result.ContainsKey("a"));
            Assert.That(result.ContainsKey("b"));
            Assert.That(result.ContainsKey("c"));

            Assert.AreEqual(3, result["test"].Length);
            Assert.That(result["test"].Contains("first"));
            Assert.That(result["test"].Contains("second"));
            Assert.That(result["test"].Contains("third"));

            Assert.AreEqual(1, result["a"].Length);
            Assert.That(result["a"].Contains("a"));

            Assert.AreEqual(2, result["b"].Length);
            Assert.That(result["b"].Contains("b"));
            Assert.That(result["b"].Contains("b exception"));

            Assert.AreEqual(1, result["c"].Length);
            Assert.That(result["c"].Contains("c exception"));
        }
    }
}
