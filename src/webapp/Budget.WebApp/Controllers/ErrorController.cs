using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Budget.WebApp.Models;

namespace Budget.WebApp.Controllers
{
    public partial class ErrorController : BaseController
    {
        public virtual ActionResult Error()
        {
            return Handle(HttpStatusCode.InternalServerError, "Internal server error");
        }

        public virtual ActionResult NotFound()
        {
            return Handle(HttpStatusCode.NotFound, "Not found");
        }

        public virtual ActionResult Forbidden()
        {
            return Handle(HttpStatusCode.Forbidden, "Forbidden");
        }

        public virtual ActionResult BadRequest()
        {
            return Handle(HttpStatusCode.BadRequest, "Bad request");
        }

        private ActionResult Handle(HttpStatusCode statusCode, string message)
        {
            Response.StatusCode = (int)statusCode;

            if (Request.IsAjaxRequest())
            {
                return Json(new ErrorModel(message));
            }

            return View();
        }
    }
}