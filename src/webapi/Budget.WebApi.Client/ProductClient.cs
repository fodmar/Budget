using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.WebApi.Client
{
    public class ProductClient : ClientBase, IProductRepository
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

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await
                this.CreateRequest()
                    .AsGet()
                    .Send<Product[]>();
        }

        public async Task<Product> Insert(Product product)
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

        public Task Delete(Product product)
        {
            return 
                this.CreateRequest()
                    .AddUriParam(product.Id)
                    .AsDelete()
                    .Send();
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
