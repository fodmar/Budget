using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Budget.WebApp.Utils;

namespace Budget.WebApp.Controllers
{
    public abstract partial class BaseController : Controller
    {
        protected ISessionHelper sessionHelper;

        protected BaseController()
        {
        }

        public BaseController(ISessionHelper sessionHelper)
        {
            this.sessionHelper = sessionHelper;
        }
    }
}