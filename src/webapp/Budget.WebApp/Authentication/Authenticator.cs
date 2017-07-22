using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using Budget.BusinessLogic.UserManagement;
using Budget.ObjectModel;
using Budget.WebApp.Models;
using Budget.WebApp.Utils;

namespace Budget.WebApp.Authentication
{
    public class Authenticator : IAuthenticator
    {
        private readonly ILoginService loginService;
        private readonly ISessionHelper sessionHelper;
        private readonly IFormsAuthentication formsAuthentication;

        public Authenticator(
            ILoginService loginService,
            ISessionHelper sessionHelper,
            IFormsAuthentication formsAuthentication)
        {
            this.loginService = loginService;
            this.sessionHelper = sessionHelper;
            this.formsAuthentication = formsAuthentication;
        }

        public async Task<bool> Login(LoginModel model)
        {
            LoginAttempt loginAttempt = await this.loginService.Login(model.Login, model.Password);
            User user = loginAttempt.User;

            if (user == null)
            {
                return false;
            }

            this.formsAuthentication.SetAuthCookie(user.Id.ToString(), true);
            this.sessionHelper.UserId = user.Id;
            return true;
        }

        public void Logout()
        {
            this.formsAuthentication.SignOut();
            this.sessionHelper.Clear();
        }
    }
}