using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ObjectModel
{
    public interface ICorrelationIdProvider
    {
        Guid CurrentId { get; set; }
    }
}
