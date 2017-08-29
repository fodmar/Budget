namespace Budget.WebApi.DependencyResolution.Registries
{
    using Budget.BusinessLogic.UserManagement;
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
            For<IReceiptSaver>().Use<ReceiptRepository>();
            For<IBudgetDatabase>().Use<BudgetDatabase>();

            For<IUserProvider>().Use<UserRepository>();

            For<IProductRepository>().Use<ProductRepository>();
        }
    }
}