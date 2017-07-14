using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.WebApi.Client
{
    public interface IConfigurationProvider
    {
        string BudgetApiUrl { get; }
    }
}
