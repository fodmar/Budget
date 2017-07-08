using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Budget.DataAccess;
using Budget.Database;
using Budget.ObjectModel;

namespace Budget.WebApi.Controllers
{
    public class ReceiptsController : ApiController
    {
        private readonly IReceiptProvider receiptProvider;

        public ReceiptsController(IReceiptProvider receiptProvider)
        {
            this.receiptProvider = receiptProvider;
        }

        [HttpGet]
        public Receipt GetReceipt(
            [FromUri] int id)
        {
            return this.receiptProvider.GetReceipt(id);
        }

        [HttpGet]
        public Receipt[] GetReceipts()
        {
            return this.receiptProvider.GetReceipts().ToArray();
        }

        [HttpGet]
        public Receipt[] GetReceiptsFromDateRange(
            [FromUri] DateTime? from,
            [FromUri] DateTime? to)
        {
            return this.receiptProvider.GetReceiptsByDates(from, to).ToArray();
        }
    }
}
