using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.DataAccess.Query;

namespace Budget.DataAccess
{
    public class DataAccessFacade : IDataAccessFacade
    {
        public DataAccessFacade(IGetReceiptsByDate getReceiptsByDate)
        {
            this.GetReceiptsByDate = getReceiptsByDate;
        }

        public IGetReceiptsByDate GetReceiptsByDate { get; private set; }
    }
}
