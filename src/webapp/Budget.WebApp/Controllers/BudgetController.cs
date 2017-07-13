﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Budget.ObjectModel;
using Budget.WebApi.Client;

namespace Budget.WebApp.Controllers
{
    public class BudgetController : Controller
    {
        public ActionResult Overview()
        {
            return this.View();
        }

        public async Task<ActionResult> GetReceipts(DateTime from, DateTime to)
        {
            IReceiptProvider provider = new ReceiptClient();
            return Json(await provider.GetReceiptsByDatesAsync(from, to));
        }
    }
}