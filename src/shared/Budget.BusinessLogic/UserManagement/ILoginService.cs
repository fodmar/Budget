using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Budget.BusinessLogic.UserManagement
{
    public interface ILoginService
    {
        LoginAttempt Login(string login, string password);
    }
}
