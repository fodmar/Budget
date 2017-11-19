using System.Runtime.Caching;
using Budget.ObjectModel;
using Budget.Utils.Cache;
using Budget.Utils.Http;
using Budget.WebApi.Client;
using Budget.WebApp.Authentication;
using Budget.WebApp.Configuration;
using Budget.WebApp.Utils;
using StructureMap.Configuration.DSL;

namespace Budget.WebApp.DependencyResolution.Registries
{
    public class ControllerRegistry : Registry
    {
        public ControllerRegistry()
        {
            For<IReceiptProvider>().Use<ReceiptClient>();
            For<ISaver<Receipt>>().Use<ReceiptClient>();
            For<IConfigurationProvider>().Use<BudgetApiConfigurationProvider>();
            For<IHeadersProvider>().Use<BudgetApiHeadersProvider>();
            For<IAuthenticator>().Use<Authenticator>();
            For<IApiClient>().Use<ApiClient>();

            For<IRepository<Product>>().Use<RepositoryCache<Product>>().Ctor<IRepository<Product>>().Is<ProductClient>();
            For<ICache>().Use<CacheWrapper>();
            For<ObjectCache>().Use(new MemoryCache("BudgetWebAppMemoryCache"));
        }
    }
}