using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Budget.DataAccess;
using Budget.Database;
using Budget.ObjectModel;
using Budget.WebApi.ModelBinders;

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
            return await this.receiptProvider.GetReceiptAsync(id);
        }

        [HttpGet]
        public async Task<Receipt[]> GetReceipts()
        {
            IEnumerable<Receipt> receipts = await this.receiptProvider.GetReceiptsAsync();
            return receipts.ToArray();
        }

        [HttpGet]
        public async Task<Receipt[]> GetReceiptsFromDateRange(
            [ModelBinder(typeof(DateTimeFromUnixTimeStampBinder))] DateTime? from,
            [ModelBinder(typeof(DateTimeFromUnixTimeStampBinder))] DateTime? to)
        {
            IEnumerable<Receipt> receipts = await this.receiptProvider.GetReceiptsByDatesAsync(from, to);
            return receipts.ToArray();
        }
    }
}
