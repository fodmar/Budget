using Budget.BusinessLogic.UserManagement;
using Budget.DataAccess;
using Budget.Database;
using Budget.ObjectModel;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Budget.WebApi.DependencyResolution.Registries
{
    public class ControllerRegistry : Registry
    {
        public ControllerRegistry() 
        {
            For<IReceiptProvider>().Use<ReceiptRepository>();
            For<ISaver<Receipt>>().Use<ReceiptRepository>();
            For<IBudgetDatabase>().Use<BudgetDatabase>();

            For<IUserProvider>().Use<UserRepository>();

            For<IRepository<Product>>().Use<Repository<Product>>().Ctor<IDatabase>().Is<BudgetDatabase>();
        }
    }
}