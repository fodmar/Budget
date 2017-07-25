using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Budget.ObjectModel;
using Budget.WebApi.Client;
using Budget.WebApp.Utils;

namespace Budget.WebApp.Controllers
{
    public partial class OverviewController : BaseController
    {
        private IReceiptProvider receiptProvider;

        public OverviewController(
            ISessionHelper sessionHelper,
            IReceiptProvider receiptProvider)
            : base(sessionHelper)
        {
            this.receiptProvider = receiptProvider;
        }

        public virtual ActionResult Overview()
        {
            return this.View();
        }

        public virtual async Task<ActionResult> GetReceipts(DateTime start, DateTime end)
        {
            int userId = this.sessionHelper.UserId;
            IEnumerable<Receipt> receipts = await this.receiptProvider.GetReceiptsByDates(userId, start, end);

            var json = from receipt in receipts
                       select new
                       {
                           id = receipt.Id,
                           start = receipt.Date,
                           title = receipt.Entries.Sum(e => e.Amount)
                       };

            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}