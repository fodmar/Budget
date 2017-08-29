using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.DataAccess;
using Budget.Database;
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
                IProductRepository repository = new ProductRepository(db);

                IEnumerable<Product> products = await repository.GetAll();
            }
        }

        [Test]
        [Ignore]
        public async void Insert()
        {
            using (IBudgetDatabase db = new BudgetDatabase())
            {
                IProductRepository repository = new ProductRepository(db);

                Product newProduct = new Product();
                newProduct.Id = 666;
                newProduct.Name = "test";

                newProduct = await repository.Insert(newProduct);
            }
        }

        [Test]
        [Ignore]
        public async void Update()
        {
            using (IBudgetDatabase db = new BudgetDatabase())
            {
                IProductRepository repository = new ProductRepository(db);

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
                IProductRepository repository = new ProductRepository(db);

                Product product = new Product();
                product.Id = 666;
                product.Name = "non-existing";

                await repository.Delete(product);
            }
        }
    }
}
