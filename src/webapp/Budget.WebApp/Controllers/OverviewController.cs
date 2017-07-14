using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Budget.ObjectModel;
using Budget.WebApi.Client;

namespace Budget.WebApp.Controllers
{
    public partial class OverviewController : Controller
    {
        private IReceiptProvider receiptProvider;

        public OverviewController(IReceiptProvider receiptProvider)
        {
            this.receiptProvider = receiptProvider;
        }

        public virtual ActionResult Overview()
        {
            return this.View();
        }

        public virtual async Task<ActionResult> GetReceipts(DateTime from, DateTime to)
        {
            return Json(await this.receiptProvider.GetReceiptsByDatesAsync(from, to));
        }
    }
}