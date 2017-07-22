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

        public virtual async Task<ActionResult> GetReceipts(DateTime from, DateTime to)
        {
            int userId = this.sessionHelper.UserId;
            return Json(await this.receiptProvider.GetReceiptsByDates(userId, from, to));
        }
    }
}