using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Budget.BusinessLogic.UserManagement;
using Budget.ObjectModel;

namespace Budget.WebApi.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserProvider userProvider;

        public UserController(IUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }

        [HttpGet]
        public async Task<User> Find(
            [FromUri] string login,
            [FromUri] string hash)
        {
            return await this.userProvider.FindUser(new UserPassword(login, hash));
        }
    }
}
