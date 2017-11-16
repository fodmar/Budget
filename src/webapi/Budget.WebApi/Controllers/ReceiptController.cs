using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Budget.EntityFramework;
using Budget.EntityFramework;
using Budget.ObjectModel;
using Budget.WebApi.ModelBinders;

namespace Budget.WebApi.Controllers
{
    [RoutePrefix("api/receipt")]
    public class ReceiptController : BaseController
    {
        private readonly IReceiptProvider receiptProvider;
        private readonly ISaver<Receipt> saver;

        public ReceiptController(
            IReceiptProvider receiptProvider,
            ISaver<Receipt> saver)
        {
            this.receiptProvider = receiptProvider;
            this.saver = saver;
        }

        [HttpGet]
        [Route("{userId}/{receiptId}")]
        public async Task<Receipt> GetReceipt(
            [FromUri] int userId,
            [FromUri] int receiptId)
        {
            return await this.receiptProvider.GetReceipt(userId, receiptId);
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<Receipt[]> GetReceipts(
            [FromUri] int userId)
        {
            IEnumerable<Receipt> receipts = await this.receiptProvider.GetReceipts(userId);
            return receipts.ToArray();
        }

        [HttpGet]
        [Route("{userId}/{from}/{to}")]
        public async Task<Receipt[]> GetReceiptsFromDateRange(
            [FromUri] int userId,
            [ModelBinder(typeof(DateTimeFromUnixTimeStampBinder))] DateTime? from,
            [ModelBinder(typeof(DateTimeFromUnixTimeStampBinder))] DateTime? to)
        {
            IEnumerable<Receipt> receipts = await this.receiptProvider.GetReceiptsByDates(userId, from, to);
            return receipts.ToArray();
        }

        [HttpPut]
        [Route("")]
        public async Task<Receipt> SaveReceipt(
            [FromBody] Receipt receipt)
        {
            await this.saver.Save(receipt);
            return receipt;
        }
    }
}
