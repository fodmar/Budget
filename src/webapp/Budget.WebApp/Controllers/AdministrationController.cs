﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Budget.WebApp.Controllers
{
    public partial class AdministrationController : BaseController
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}