using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ObjectModel
{
    public interface IReceiptProvider
    {
        Task<Receipt> GetReceiptAsync(int id);

        Task<IEnumerable<Receipt>> GetReceiptsAsync();

        Task<IEnumerable<Receipt>> GetReceiptsByDatesAsync(DateTime? from, DateTime? to);
    }
}
