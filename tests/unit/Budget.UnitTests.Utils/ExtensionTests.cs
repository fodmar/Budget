using Budget.Utils.Extensions;
using NUnit.Framework;

namespace Budget.UnitTests.Utils
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void BooleanToLower()
        {
            Assert.AreEqual("false", false.ToLowerString());
            Assert.AreEqual("False", false.ToString());

            Assert.AreEqual("true", true.ToLowerString());
            Assert.AreEqual("True", true.ToString());
        }

        [Test]
        public void ToMD5String()
        {
            Assert.AreEqual("0cc175b9c0f1b6a831c399e269772661", "a".ToMD5String());
        }
    }
}
