using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ObjectModel
{
    public class UserPassword
    {
        public int UserId { get; set; }

        public string UserLogin { get; set; }

        public string Hash { get; set; }
    }
}
