using System.Collections.Generic;
using System.Threading.Tasks;
using Budget.ObjectModel;
using Budget.Utils.Http;

namespace Budget.WebApi.Client
{
    public class ProductClient : ClientBase, IRepository<Product>
    {
        protected override string UriController
        {
	        get { return "product/"; }
        }

        public ProductClient(
            IApiClient client,
            IConfigurationProvider configurationProvider,
            IHeadersProvider headersProvider)
            : base(client, configurationProvider, headersProvider)
        {
        }

        public async Task<IEnumerable<Product>> ReadAll()
        {
            ApiRequest request = this.CreateRequest().AsGet();
            ApiResponse response = await this.apiClient.Send(request);

            return await response.ReadAs<Product[]>();
        }

        public async Task<Product> Save(Product product)
        {
            ApiRequest request = this.CreateRequest().AsPut().WithBody(this.ProductToJsonForInsert(product));
            ApiResponse response = await this.apiClient.Send(request);

            return await response.ReadAs<Product>();
        }

        public async Task Update(Product product)
        {
            ApiRequest request = this.CreateRequest().AsPost().WithBody(product);
            await this.apiClient.Send(request);
        }

        public async Task Remove(Product product)
        {
            ApiRequest request = this.CreateRequest().AsDelete().WithBody(product);
            await this.apiClient.Send(request);
        }

        public async Task<Product> GetById(int id)
        {
            ApiRequest request = this.CreateRequest().AddUriParam(id);
            ApiResponse response = await this.apiClient.Send(request);

            return await response.ReadAs<Product>();
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
