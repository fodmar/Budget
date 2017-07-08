using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ObjectModel
{
    public interface IReceiptProvider
    {
        Receipt GetReceipt(int id);

        IEnumerable<Receipt> GetReceipts();

        IEnumerable<Receipt> GetReceiptsByDates(DateTime? from, DateTime? to);
    }
}
