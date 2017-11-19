using Budget.Utils.Http;

namespace Budget.WebApi.Client
{
    public abstract class ClientBase
    {
        protected readonly IHeadersProvider headersProvider;
        protected readonly IApiClient apiClient;
        private string budgetApiUrl;
        
        public ClientBase(
            IApiClient apiClient,
            IConfigurationProvider configurationProvider,
            IHeadersProvider headersProvider)
        {
            this.apiClient = apiClient;
            this.budgetApiUrl = configurationProvider.BudgetApiUrl;
            this.headersProvider = headersProvider;
        }

        protected abstract string UriController { get; }

        protected virtual void AddHeaders(ApiRequest request)
        {
            request.AddHeader("correlationId", this.headersProvider.CorrelationId);
        }

        protected ApiRequest CreateRequest()
        {
            ApiRequest request = new ApiRequest(this.budgetApiUrl + this.UriController);

            this.AddHeaders(request);

            return request;
        }
    }
}
