using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Budget.ObjectModel;
using Budget.WebApi.Client;
using Budget.WebApp.Models;
using Budget.WebApp.Utils;
using Budget.WebApp.Extensions;
using Budget.WebApp.Translators;
using Budget.WebApp.Models.Json;

namespace Budget.WebApp.Controllers
{
    public partial class OverviewController : BaseController
    {
        private IReceiptProvider receiptProvider;
        private ISaver<Receipt> receiptSaver;
        private IReader<Product> productReader;

        public OverviewController(
            ISessionHelper sessionHelper,
            IReceiptProvider receiptProvider,
            ISaver<Receipt> receiptSaver,
            IReader<Product> productReader)
            : base(sessionHelper)
        {
            this.receiptProvider = receiptProvider;
            this.receiptSaver = receiptSaver;
            this.productReader = productReader;
        }

        public virtual async Task<ActionResult> Overview()
        {
            ProductsDataListModel productsModel = new ProductsDataListModel();
            productsModel.Products = await this.productReader.ReadAll();

            OverviewModel model = new OverviewModel();
            model.SaveReceipt = new SaveReceiptModel();
            model.Products = productsModel;

            return this.View(model);
        }

        public virtual async Task<ActionResult> GetReceipts(DateTime start, DateTime end)
        {
            int userId = this.sessionHelper.UserId;
            IEnumerable<Receipt> receipts = await this.receiptProvider.GetReceiptsByDates(userId, start, end);
            IEnumerable<FullcalendarEvent> json = receipts.Select(r => new FullcalendarEvent(r));

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public virtual async Task<ActionResult> SaveReceipt(SaveReceiptModel saveModel)
        {
            if (!ModelState.IsValid)
            {
                this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ModelState.PropertiesErrors());
            }

            ReceiptTranslator translator = new ReceiptTranslator();
            Receipt model = translator.Translate(saveModel, this.sessionHelper.UserId);

            Receipt saved = await this.receiptSaver.Save(model);
            return Json(new FullcalendarEvent(saved));
        }
    }
}