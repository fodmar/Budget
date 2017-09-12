using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Budget.Database;
using Budget.ObjectModel;
using Budget.DataAccess.Query;

namespace Budget.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private IBudgetDatabase budgetDatabase;

        public ProductRepository(IBudgetDatabase budgetDatabase)
        {
            this.budgetDatabase = budgetDatabase;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await this.budgetDatabase.Select<Product>().ToListAsync();
        }

        public Task<Product> Insert(Product product)
        {
            return this.budgetDatabase.Insert(product);
        }

        public Task Update(Product product)
        {
            return this.budgetDatabase.Update(product);
        }

        public Task Delete(Product product)
        {
            return this.budgetDatabase.Delete(product);
        }
    }
}
