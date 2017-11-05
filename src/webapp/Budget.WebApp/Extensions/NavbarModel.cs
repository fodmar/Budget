using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Budget.Resources;

namespace Budget.WebApp.Extensions
{
    public class NavbarModel
    {
        private string controller;
        private string action;
        private UrlHelper urlHelper;

        public NavbarModel(RouteValueDictionary routeData, UrlHelper urlHelper)
        {
            this.controller = routeData["controller"] as string;
            this.action = routeData["action"] as string;
            this.urlHelper = urlHelper;

            var tabs = new List<NavbarTabModel>();
            tabs.Add(this.Tab(MVC.Overview.Name, MVC.Overview.ActionNames.Overview, Text.Calendar));
            tabs.Add(this.Tab(MVC.Product.Name, MVC.Product.ActionNames.Index, Text.Administration));

            this.Tabs = tabs;
        }

        public string UserName { get; set; }
        public IEnumerable<NavbarTabModel> Tabs { get; set; }

        private NavbarTabModel Tab(string controller, string action, string text)
        {
            return new NavbarTabModel(
                this.urlHelper.Action(action, controller),
                text,
                this.controller == controller && this.action == action);
        }
    }
}