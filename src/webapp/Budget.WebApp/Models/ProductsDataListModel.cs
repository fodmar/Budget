using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Budget.ObjectModel;

namespace Budget.WebApp.Models
{
    public class ProductsDataListModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}