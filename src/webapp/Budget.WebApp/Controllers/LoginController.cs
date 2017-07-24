using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Budget.BusinessLogic.UserManagement;
using Budget.Resources;
using Budget.WebApp.Authentication;
using Budget.WebApp.Models;
using Budget.WebApp.Utils;
using User = Budget.ObjectModel.User;

namespace Budget.WebApp.Controllers
{
    public partial class LoginController : BaseController
    {
        private readonly IAuthenticator authenticator;

        public LoginController(IAuthenticator authenticator)
        {
            this.authenticator = authenticator;
        }

        [AllowAnonymous]
        public virtual ActionResult Login(string returnUrl = null)
        {
            return this.View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        public async virtual Task<ActionResult> Login(LoginModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            bool correct = await this.authenticator.Login(model);

            if (!correct)
            {
                this.ModelState.AddModelError(string.Empty, Text.UsernameAndPasswordDontMatch);
                model.Password = string.Empty;
                return this.View(model);
            }

            if (string.IsNullOrEmpty(model.ReturnUrl))
            {
                model.ReturnUrl = @"~/";
            }

            return this.Redirect(Url.Content(model.ReturnUrl));
        }

        public virtual ActionResult Logout()
        {
            this.authenticator.Logout();
            return this.RedirectToAction(MVC.Login.ActionNames.Login);
        }
    }
}