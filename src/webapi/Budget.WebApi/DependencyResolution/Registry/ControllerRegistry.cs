namespace Budget.WebApi.DependencyResolution.Registry
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
            For<IReceiptProvider>().Use<DataAccessFacade>();
            For<IBudgetDatabase>().Use<BudgetDatabase>();
        }
    }
}