﻿using System;
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

namespace Budget.WebApp.Controllers
{
    public partial class OverviewController : BaseController
    {
        private IReceiptProvider receiptProvider;
        private IReceiptSaver receiptSaver;

        public OverviewController(
            ISessionHelper sessionHelper,
            IReceiptProvider receiptProvider,
            IReceiptSaver receiptSaver)
            : base(sessionHelper)
        {
            this.receiptProvider = receiptProvider;
            this.receiptSaver = receiptSaver;
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
        
        [HttpPost]
        public virtual async Task<ActionResult> SaveReceipt(SaveReceiptModel receipt)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //receipt.UserId = this.sessionHelper.UserId;
            //Receipt saved = await this.receiptSaver.Save(receipt);
            return Json(receipt);
        }
    }
}