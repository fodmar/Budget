using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.Caching
{
    public class ProductRepositoryCache : IRepository<Product>
    {
        private const string productsKey = "Product_GetAll";

        private readonly ICache cache;
        private readonly IRepository<Product> repository;

        public ProductRepositoryCache(ICache cache, IRepository<Product> repository)
        {
            this.cache = cache;
            this.repository = repository;
        }

        public Task<IEnumerable<Product>> ReadAll()
        {
            Func<Task<IEnumerable<Product>>> func = async () => await this.repository.ReadAll();

            return this.cache.GetOrPut(productsKey, func);
        }

        public async Task<Product> Save(Product product)
        {
            Product inserted = await this.repository.Save(product);

            if (!this.cache.Contains(productsKey))
            {
                return inserted;
            }

            List<Product> products = (await this.ReadAll()).ToList();
            products.Add(inserted);
            this.cache.Put(productsKey, Task<IEnumerable<Product>>.FromResult(products.AsEnumerable()));
            return inserted;
        }

        public async Task Update(Product product)
        {
            await this.repository.Update(product);

            if (!this.cache.Contains(productsKey))
            {
                return;
            }

            List<Product> products = (await this.ReadAll()).ToList();

            for (int i = 0; i < products.Count; i++)
            {
                if (product.Id == products[i].Id)
                {
                    products[i] = product;
                    break;
                }
            }

            this.cache.Put(productsKey, Task<IEnumerable<Product>>.FromResult(products.AsEnumerable()));
        }

        public async Task Remove(Product product)
        {
            await this.repository.Remove(product);

            if (!this.cache.Contains(productsKey))
            {
                return;
            }

            List<Product> products = (await this.ReadAll()).ToList();
            products.Remove(products.Find(p => p.Id == product.Id));
            this.cache.Put(productsKey, Task<IEnumerable<Product>>.FromResult(products.AsEnumerable()));
        }
    }
}
