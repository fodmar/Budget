using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.BusinessLogic.UserManagement;
using Budget.ObjectModel;

namespace Budget.WebApi.Client
{
    public class UserClient : ClientBase, IUserProvider
    {
        protected override string UriController
        {
            get { return "api/user/"; }
        }

        public UserClient(
            IConfigurationProvider configurationProvider,
            IHeadersProvider headersProvider) 
            : base(configurationProvider, headersProvider)
        {
        }
    
        public async Task<User> FindUser(UserPassword password)
        {
 	        return await
                this.CreateRequest()
                    .AddUriParam(password.UserLogin)
                    .AddUriParam(password.Hash)
                    .Send<User>();
        }

        protected override void AddHeaders(ApiRequest request)
        {
            request.AddHeader("correlationId", this.headersProvider.CorrelationId);
        }
    }
}
