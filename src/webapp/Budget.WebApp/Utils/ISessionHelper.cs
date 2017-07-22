using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.WebApp.Utils
{
    public interface ISessionHelper
    {
        void Clear();

        int UserId { get; set; }
    }
}
