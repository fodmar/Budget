using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ObjectModel
{
    public interface IReceiptSaver
    {
        Task<Receipt> Save(Receipt receipt);
    }
}
