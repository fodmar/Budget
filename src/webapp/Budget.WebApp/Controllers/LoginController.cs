using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Budget.BusinessLogic.UserManagement;
using Budget.WebApp.Authentication;
using Budget.WebApp.Models;
using Budget.WebApp.Utils;
using User = Budget.ObjectModel.User;

namespace Budget.WebApp.Controllers
{
    public partial class LoginController : Controller
    {
        private readonly IFormsAuthentication formsAuthentication;

        public LoginController(IFormsAuthentication formsAuthentication)
        {
            this.formsAuthentication = formsAuthentication;
        }

        public virtual ActionResult Login(string returnUrl = null)
        {
            return this.View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async virtual Task<ActionResult> Login(LoginModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            bool correct = await this.formsAuthentication.Login(model);

            if (!correct)
            {
                this.ModelState.AddModelError(string.Empty, "User name or password is invalid");
                model.Password = string.Empty;
                return this.View(model);
            }

            string redirectTo = model.ReturnUrl;

            if (string.IsNullOrEmpty(redirectTo))
            {
                redirectTo = @"~/";
            }

            return this.Redirect(Url.Content(redirectTo));
        }

        public virtual ActionResult Logout()
        {
            return this.View();
        }
    }
}