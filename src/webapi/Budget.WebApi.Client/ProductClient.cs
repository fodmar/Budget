using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.WebApi.Client
{
    public class ProductClient : ClientBase, IRepository<Product>
    {
        protected override string UriController
        {
	        get { return "api/product/"; }
        }

        public ProductClient(
            IConfigurationProvider configurationProvider,
            IHeadersProvider headersProvider)
            : base(configurationProvider, headersProvider)
        {
        }

        public async Task<IEnumerable<Product>> ReadAll()
        {
            return await
                this.CreateRequest()
                    .AsGet()
                    .Send<Product[]>();
        }

        public async Task<Product> Save(Product product)
        {
            return await
                this.CreateRequest()
                    .AddBody(this.ProductToJsonForInsert(product))
                    .AsPut()
                    .Send<Product>();
        }

        public Task Update(Product product)
        {
            return 
                this.CreateRequest()
                    .AddBody(product)
                    .AsPost()
                    .Send();
        }

        public Task Remove(Product product)
        {
            return 
                this.CreateRequest()
                    .AddUriParam(product.Id)
                    .AsDelete()
                    .Send();
        }

        public async Task<Product> GetById(int id)
        {
            return await
                this.CreateRequest()
                    .AddUriParam(id)
                    .AsGet()
                    .Send<Product>();
        }

        private dynamic ProductToJsonForInsert(Product product)
        {
            return new
            {
                Name = product.Name
            };
        }
    }
}
