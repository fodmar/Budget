using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ObjectModel
{
    public interface IReceiptProvider
    {
        Task<Receipt> GetReceipt(int userId, int receiptId);

        Task<IEnumerable<Receipt>> GetReceipts(int userId);

        Task<IEnumerable<Receipt>> GetReceiptsByDates(int userId, DateTime? from, DateTime? to);
    }
}
