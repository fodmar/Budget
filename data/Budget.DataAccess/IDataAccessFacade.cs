using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.DataAccess.Query;

namespace Budget.DataAccess
{
    public interface IDataAccessFacade
    {
        IGetReceiptsByDate GetReceiptsByDate { get; }
    }
}
