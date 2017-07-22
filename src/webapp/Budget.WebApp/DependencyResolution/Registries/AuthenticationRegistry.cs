using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Budget.BusinessLogic.UserManagement;
using Budget.WebApi.Client;
using Budget.WebApp.Authentication;
using StructureMap.Configuration.DSL;

namespace Budget.WebApp.DependencyResolution.Registries
{
    public class AuthenticationRegistry : Registry
    {
        public AuthenticationRegistry()
        {
            For<ILoginService>().Use<LoginService>();
            For<IUserProvider>().Use<UserClient>();
            For<IFormsAuthentication>().Use<FormsAuthenticationWrapper>();
        }
    }
}