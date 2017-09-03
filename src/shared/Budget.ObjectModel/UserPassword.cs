using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ObjectModel
{
    public class UserPassword
    {
        public UserPassword()
        {
        }

        public UserPassword(string login, string hash)
        {
            this.UserLogin = login;
            this.Hash = hash;
        }

        public int UserId { get; set; }

        public string UserLogin { get; set; }

        public string Hash { get; set; }

        public User User { get; set; }
    }
}
