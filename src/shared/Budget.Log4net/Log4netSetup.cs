using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;

namespace Budget.Log4net
{
    public static class Log4netSetup
    {
        public static void Setup()
        {
            Setup("log4net.config");
        }

        public static void Setup(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(string.Format("File not found: {0} current dir: {1}", fileName, Directory.GetCurrentDirectory()));
            }

            XmlConfigurator.ConfigureAndWatch(new FileInfo(fileName));
        }
    }
}
