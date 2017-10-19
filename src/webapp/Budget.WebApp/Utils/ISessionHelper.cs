using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.WebApp.Utils
{
    public interface ISessionHelper
    {
        void Clear();

        User User { get; set; }
    }
}
