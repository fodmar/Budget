using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Budget.WebApi.Filters;

namespace Budget.WebApi.Controllers
{
    [CorrelationId]
    public abstract class BaseController : ApiController
    {
    }
}