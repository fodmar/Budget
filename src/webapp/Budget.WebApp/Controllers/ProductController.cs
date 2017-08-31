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
    public partial class ProductController : BaseController
    {
        private readonly IProductRepository productRepository;

        public ProductController(
            ISessionHelper sessionHelper,
            IProductRepository productRepository)
            : base(sessionHelper)
        {
            this.productRepository = productRepository;
        }

        public virtual async Task<ActionResult> GetProductsDictionary()
        {
            IEnumerable<Product> products = await this.productRepository.GetAll();
            return this.Json(products.ToArray());
        }
    }
}