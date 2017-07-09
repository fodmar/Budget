using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Budget.DataAccess;
using Budget.Database;
using Budget.ObjectModel;

namespace Budget.WebApi.Controllers
{
    public class ReceiptController : BaseController
    {
        private readonly IReceiptProvider receiptProvider;

        public ReceiptController(IReceiptProvider receiptProvider)
        {
            this.receiptProvider = receiptProvider;
        }

        [HttpGet]
        public async Task<Receipt> GetReceipt(
            [FromUri] int id)
        {
            return this.receiptProvider.GetReceipt(id);
        }

        [HttpGet]
        public async Task<Receipt[]> GetReceipts()
        {
            return this.receiptProvider.GetReceipts().ToArray();
        }

        [HttpGet]
        public async Task<Receipt[]> GetReceiptsFromDateRange(
            [FromUri] DateTime? from,
            [FromUri] DateTime? to)
        {
            return this.receiptProvider.GetReceiptsByDates(from, to).ToArray();
        }
    }
}
