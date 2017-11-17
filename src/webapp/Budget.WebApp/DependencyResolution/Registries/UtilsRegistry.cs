using Budget.Log4net;
using Budget.Utils;
using Budget.Utils.Log;
using Budget.Utils.Trace;
using Budget.WebApp.Utils;
using StructureMap.Configuration.DSL;

namespace Budget.WebApp.DependencyResolution.Registries
{
    public class UtilsRegistry : Registry
    {
        public UtilsRegistry()
        {
            For<ICorrelationIdProvider>().Use<CorrelationIdProvider>();
            For<ISessionHelper>().Use<SessionHelper>();
            For<ICookieHelper>().Use<CookieHelper>();
            For<ILogger>().Use<Log4netWrapper>().Ctor<string>("loggerName").Is("default");
            For<IErrorHandler>().Use<ErrorHandler>();
        }
    }
}