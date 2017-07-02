using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.Domain;

namespace Budget.DataAccess.Query
{
    public interface IGetReceiptsByDate
    {
        IEnumerable<Receipt> Run(DateTime? from, DateTime? to);
    }
}
