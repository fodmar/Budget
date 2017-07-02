using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.Database;
using Budget.Domain;

namespace Budget.DataAccess.Query
{
    public class GetReceiptsByDate : IGetReceiptsByDate
    {
        private readonly IBudgetDatabase database;

        public GetReceiptsByDate(IBudgetDatabase database)
        {
            this.database = database;
        }

        public IEnumerable<Receipt> Run(DateTime? from, DateTime? to)
        {
            return (from receipt in this.database.Receipts
                    where ((!@from.HasValue || receipt.Date > @from.Value) && (!to.HasValue || receipt.Date < to.Value))
                    select receipt);
        }
    }
}
