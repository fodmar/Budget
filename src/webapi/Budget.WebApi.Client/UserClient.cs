using System.Threading.Tasks;
using Budget.BusinessLogic.UserManagement;
using Budget.ObjectModel;
using Budget.Utils.Http;

namespace Budget.WebApi.Client
{
    public class UserClient : ClientBase, IUserProvider
    {
        protected override string UriController
        {
            get { return "user/"; }
        }

        public UserClient(
            IApiClient client,
            IConfigurationProvider configurationProvider,
            IHeadersProvider headersProvider) 
            : base(client, configurationProvider, headersProvider)
        {
        }
    
        public async Task<User> FindUser(UserPassword password)
        {
            ApiRequest request = this.CreateRequest().AddUriParam(password.UserLogin).AddUriParam(password.Hash);
            ApiResponse response = await this.apiClient.Send(request);

            return await response.ReadAs<User>();
        }
    }
}
