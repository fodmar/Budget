using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Budget.ObjectModel;
using Budget.WebApp.Utils;
using Budget.WebApp.Extensions;

namespace Budget.WebApp.Controllers
{
    public abstract class ObjectController<T> : BaseController
    {
        [Obsolete("This constructor is required by T4MVC lib, don't use it")]
        protected ObjectController()
        {
        }

        private readonly IRepository<T> repository;

        public ObjectController(
            ISessionHelper sessionHelper,
            IRepository<T> repository)
            : base(sessionHelper)
        {
            this.repository = repository;
        }

        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual async Task<ActionResult> GetAll()
        {
            IEnumerable<T> objs = await this.repository.ReadAll();
            return this.Json(objs, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public virtual async Task<ActionResult> Add(T obj)
        {
            if (!ModelState.IsValid)
            {
                this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ModelState.PropertiesErrors());
            }

            T saved = await this.repository.Save(obj);
            return this.Json(saved);
        }

        [HttpDelete]
        public virtual async Task<ActionResult> Delete(T obj)
        {
            if (!ModelState.IsValid)
            {
                this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ModelState.PropertiesErrors());
            }

            await this.repository.Remove(obj);
            return this.OkStatusCode();
        }

        [HttpPost]
        public virtual async Task<ActionResult> Update(T obj)
        {
            if (!ModelState.IsValid)
            {
                this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ModelState.PropertiesErrors());
            }

            await this.repository.Update(obj);
            return this.Json(obj);
        }
    }
}