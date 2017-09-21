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
    public class ProductController : BaseController
    {
        private readonly IRepository<Product> repository;

        public ProductController(
            ISessionHelper sessionHelper,
            IRepository<Product> repository)
            : base(sessionHelper)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetProducts()
        {
            IEnumerable<Product> products = await this.repository.ReadAll();
            return this.Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}