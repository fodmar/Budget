using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Budget.WebApp.Extensions
{
    public class NavbarTabModel
    {
        public NavbarTabModel(string url, string text, bool isActive)
        {
            this.Url = url;
            this.Text = text;
            this.IsActive = isActive;
        }

        public string Url { get; set; }
        public string Text { get; set; }
        public bool IsActive { get; set; }
    }
}