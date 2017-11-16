using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.EntityFramework;
using Budget.EntityFramework;
using Budget.ObjectModel;
using NUnit.Framework;

namespace Budget.IntegrationTests.DataAccess
{
    [TestFixture]
    [Ignore]
    class ProductRepositoryTests
    {
        [Test]
        [Ignore]
        public async void GetAll()
        {
            using (IBudgetDatabase db = new BudgetDatabase())
            {
                IRepository<Product> repository = new Repository<Product>(db);

                IEnumerable<Product> products = await repository.ReadAll();
            }
        }

        [Test]
        [Ignore]
        public async void Insert()
        {
            using (IBudgetDatabase db = new BudgetDatabase())
            {
                IRepository<Product> repository = new Repository<Product>(db);

                Product newProduct = new Product();
                newProduct.Id = 666;
                newProduct.Name = "test";

                newProduct = await repository.Save(newProduct);
            }
        }

        [Test]
        [Ignore]
        public async void Update()
        {
            using (IBudgetDatabase db = new BudgetDatabase())
            {
                IRepository<Product> repository = new Repository<Product>(db);

                Product newProduct = new Product();
                newProduct.Id = 666;
                newProduct.Name = "test-update";

                await repository.Update(newProduct);
            }
        }

        [Test]
        [Ignore]
        public async void Delete()
        {
            using (IBudgetDatabase db = new BudgetDatabase())
            {
                IRepository<Product> repository = new Repository<Product>(db);

                Product product = new Product();
                product.Id = 666;
                product.Name = "non-existing";

                await repository.Remove(product);
            }
        }
    }
}
