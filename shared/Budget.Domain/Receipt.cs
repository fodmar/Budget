using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain
{
    public class Receipt
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public ICollection<ReceiptEntry> Entries { get; set; }
    }
}
