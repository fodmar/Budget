using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;
using Budget.WebApp.Models;

namespace Budget.WebApp.Authentication
{
    public interface IFormsAuthentication
    {
        Task<bool> Login(LoginModel model);
        void Logout();
    }
}
