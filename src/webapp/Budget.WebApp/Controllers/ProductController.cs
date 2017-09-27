using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Budget.ObjectModel;
using Budget.WebApp.Utils;

namespace Budget.WebApp.Controllers
{
    public partial class ProductController : ObjectController<Product>
    {
        public ProductController(
            ISessionHelper sessionHelper,
            IRepository<Product> repository)
            : base(sessionHelper, repository)
        {
        }
    }
}