using Budget.Log4net;
using Budget.ObjectModel;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Budget.WebApi.DependencyResolution.Registries
{
    public class UtilsRegistry : Registry
    {
        public UtilsRegistry() 
        {
            For<ILogger>().Use<Log4netWrapper>().Ctor<string>("loggerName").Is("default");
        }
    }
}