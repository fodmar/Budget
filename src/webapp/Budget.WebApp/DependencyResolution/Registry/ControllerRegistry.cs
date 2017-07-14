namespace Budget.WebApi.DependencyResolution.Registry
{
    using System.Web.Configuration;
    using Budget.ObjectModel;
    using Budget.WebApi.Client;
    using Budget.WebApp.Configuration;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;

    public class ControllerRegistry : Registry
    {
        public ControllerRegistry()
        {
            For<IReceiptProvider>().Use<ReceiptClient>();
            For<IConfigurationProvider>().Use<BudgetApiConfigurationProvider>();
        }
    }
}