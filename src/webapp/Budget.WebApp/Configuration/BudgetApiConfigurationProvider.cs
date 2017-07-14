using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Budget.WebApi.Client;

namespace Budget.WebApp.Configuration
{
    public class BudgetApiConfigurationProvider : IConfigurationProvider
    {
        public string BudgetApiUrl
        {
            get
            {
                return WebConfigurationManager.AppSettings["BudgetApiUrl"];
            }
        }
    }
}