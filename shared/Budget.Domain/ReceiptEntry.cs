using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain
{
    public class ReceiptEntry
    {
        public int Id { get; set; }

        public int ReceiptId { get; set; }

        public Receipt Receipt { get; set; }

        public decimal Amount { get; set; }
    }
}
