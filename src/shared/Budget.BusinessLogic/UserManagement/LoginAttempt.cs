using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.BusinessLogic.UserManagement
{
    public class LoginAttempt
    {
        public LoginAttempt(User user)
        {
            this.User = user;
        }

        public User User { get; set; }
    }
}
