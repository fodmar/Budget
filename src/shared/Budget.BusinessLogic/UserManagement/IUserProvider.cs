using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.BusinessLogic.UserManagement
{
    public interface IUserProvider
    {
        User FindUser(UserPassword password); 
    }
}
