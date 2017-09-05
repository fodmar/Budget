using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.Log4net;
using NUnit.Framework;

namespace Budget.IntegrationTests.Log4net
{
    [TestFixture]
    class Log4netTests
    {
        [Test]
        [Ignore]
        public void LogSomething()
        {
            Log4netSetup.Setup();
            Log4netWrapper log = new Log4netWrapper();

            try
            {
                this.Exception();
            }
            catch (Exception ex)
            {
                log.Error("Test exception.", ex);
            }
        }

        private void Exception()
        {
            object o = null;
            o.ToString();
        }
    }
}
