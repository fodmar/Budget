using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Budget.WebApp.Models
{
    public class OverviewModel
    {
        public ProductsDataListModel Products { get; set; }

        public SaveReceiptModel SaveReceipt { get; set; }
    }
}