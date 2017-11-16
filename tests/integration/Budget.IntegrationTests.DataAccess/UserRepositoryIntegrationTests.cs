using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.BusinessLogic.UserManagement;
using Budget.EntityFramework;
using Budget.EntityFramework;
using Budget.ObjectModel;
using NUnit.Framework;

namespace Budget.IntegrationTests.DataAccess
{
    [TestFixture]
    class UserRepositoryIntegrationTests
    {
        [Test]
        [Ignore]
        public async void FindUserIntegrationTest()
        {
            using (IBudgetDatabase database = new BudgetDatabase())
            {
                IUserProvider userProvider = new UserRepository(database);

                User user = await userProvider.FindUser(new UserPassword { UserLogin = "marcin", Hash = "d5fad0cda8f1079681ec510bb20a586c" });
            }
        }
    }
}
