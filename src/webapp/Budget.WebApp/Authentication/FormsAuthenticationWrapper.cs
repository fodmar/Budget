using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Budget.WebApp.Authentication
{
    public class FormsAuthenticationWrapper : IFormsAuthentication
    {
        public void SetAuthCookie(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {
 	        FormsAuthentication.SignOut();
        }
    }
}