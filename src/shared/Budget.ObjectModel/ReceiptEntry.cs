using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ObjectModel
{
    public class ReceiptEntry : IIdentifiable
    {
        public int Id { get; set; }

        public int ReceiptId { get; set; }

        public decimal Amount { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
