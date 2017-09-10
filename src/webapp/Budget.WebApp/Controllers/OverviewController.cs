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

namespace Budget.WebApp.Controllers
{
    public partial class OverviewController : BaseController
    {
        private IReceiptProvider receiptProvider;
        private IReceiptSaver receiptSaver;
        private IProductRepository productRepository;

        public OverviewController(
            ISessionHelper sessionHelper,
            IReceiptProvider receiptProvider,
            IReceiptSaver receiptSaver,
            IProductRepository productRepository)
            : base(sessionHelper)
        {
            this.receiptProvider = receiptProvider;
            this.receiptSaver = receiptSaver;
            this.productRepository = productRepository;
        }

        public virtual async Task<ActionResult> Overview()
        {
            ProductsDataListModel productsModel = new ProductsDataListModel();
            productsModel.Products = await this.productRepository.GetAll();

            OverviewModel model = new OverviewModel();
            model.SaveReceipt = new SaveReceiptModel();
            model.Products = productsModel;

            return this.View(model);
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
        
        [HttpPost]
        public virtual async Task<ActionResult> SaveReceipt(SaveReceiptModel receipt)
        {
            if (!ModelState.IsValid)
            {
                this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ModelState.PropertiesErrors());
            }

            //receipt.UserId = this.sessionHelper.UserId;
            //Receipt saved = await this.receiptSaver.Save(receipt);
            return Json(receipt);
        }
    }
}