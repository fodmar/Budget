using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Budget.ObjectModel;
using Budget.WebApp.Models;

namespace Budget.WebApp.Translators
{
    public class ReceiptTranslator
    {
        public Receipt Translate(SaveReceiptModel model, int userId)
        {
            Receipt result = new Receipt();
            result.Date = model.Date;
            result.UserId = userId;

            result.Entries = model.Entries.Select(e => new ReceiptEntry()
            {
                Amount = e.Amount,
                ProductId = e.ProductId
            }).ToArray();

            return result;
        }
    }
}