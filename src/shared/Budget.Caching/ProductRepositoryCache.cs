using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.Caching
{
    public class ProductRepositoryCache : IProductRepository
    {
        private const string productsKey = "Product_GetAll";

        private readonly ICache cache;
        private readonly IProductRepository repository;

        public ProductRepositoryCache(ICache cache, IProductRepository repository)
        {
            this.cache = cache;
            this.repository = repository;
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            Func<Task<IEnumerable<Product>>> func = async () => await this.repository.GetAll();

            return this.cache.GetOrPut(productsKey, func);
        }

        public async Task<Product> Insert(Product product)
        {
            Product inserted = await this.repository.Insert(product);

            if (!this.cache.Contains(productsKey))
            {
                return inserted;
            }

            List<Product> products = (await this.GetAll()).ToList();
            products.Add(inserted);
            this.cache.Put(productsKey, products);
            return inserted;
        }

        public async Task Update(Product product)
        {
            await this.repository.Update(product);

            if (!this.cache.Contains(productsKey))
            {
                return;
            }

            List<Product> products = (await this.GetAll()).ToList();

            for (int i = 0; i < products.Count; i++)
            {
                if (product.Id == products[i].Id)
                {
                    products[i] = product;
                    break;
                }
            }

            this.cache.Put(productsKey, products);
        }

        public async Task Delete(Product product)
        {
            await this.repository.Delete(product);

            if (!this.cache.Contains(productsKey))
            {
                return;
            }

            List<Product> products = (await this.GetAll()).ToList();
            products.Remove(product);
            this.cache.Put(productsKey, products);
        }
    }
}
