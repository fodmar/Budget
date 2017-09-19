using System.Runtime.Caching;
using System.Web.Configuration;
using Budget.BusinessLogic.UserManagement;
using Budget.Caching;
using Budget.ObjectModel;
using Budget.WebApi.Client;
using Budget.WebApp.Authentication;
using Budget.WebApp.Configuration;
using Budget.WebApp.Utils;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Web.Pipeline;

namespace Budget.WebApp.DependencyResolution.Registries
{
    public class ControllerRegistry : Registry
    {
        public ControllerRegistry()
        {
            For<IReceiptProvider>().Use<ReceiptClient>();
            For<IReceiptSaver>().Use<ReceiptClient>();
            For<IConfigurationProvider>().Use<BudgetApiConfigurationProvider>();
            For<IHeadersProvider>().Use<BudgetApiHeadersProvider>();
            For<IAuthenticator>().Use<Authenticator>();

            For<IProductRepository>().Use<ProductRepositoryCache>().Ctor<IProductRepository>().Is<ProductClient>();
            For<ICache>().Use<CacheWrapper>();
            For<ObjectCache>().Use(new MemoryCache("BudgetWebAppMemoryCache"));
        }
    }
}