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
            return await this.budgetDatabase.Products.ToListAsync();
        }

        public async Task<Product> Insert(Product product)
        {
            this.budgetDatabase.Products.Add(product);
            await this.budgetDatabase.SaveChangesAsync();

            return product;
        }

        public async Task Update(Product product)
        {
            this.budgetDatabase.Entry(product).State = EntityState.Modified;
            await this.budgetDatabase.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            this.budgetDatabase.Entry(product).State = EntityState.Deleted;
            await this.budgetDatabase.SaveChangesAsync();
        }
    }
}
