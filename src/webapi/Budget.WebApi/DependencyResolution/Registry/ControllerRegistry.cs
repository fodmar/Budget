namespace Budget.WebApi.DependencyResolution.Registries
{
    using Budget.DataAccess;
    using Budget.Database;
    using Budget.ObjectModel;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class ControllerRegistry : Registry 
    {
        public ControllerRegistry() 
        {
            For<IReceiptProvider>().Use<ReceiptRepository>();
            For<IBudgetDatabase>().Use<BudgetDatabase>();
        }
    }
}