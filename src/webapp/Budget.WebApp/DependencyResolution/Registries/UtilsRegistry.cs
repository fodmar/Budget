using System.Web.Configuration;
using Budget.ObjectModel;
using Budget.WebApi.Client;
using Budget.WebApp.Configuration;
using Budget.WebApp.Utils;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Web.Pipeline;

namespace Budget.WebApp.DependencyResolution.Registries
{
    public class UtilsRegistry : Registry
    {
        public UtilsRegistry()
        {
            For<ICorrelationIdProvider>().Use<CorrelationIdProvider>();
            For<ISessionHelper>().Use<SessionHelper>();
        }
    }
}