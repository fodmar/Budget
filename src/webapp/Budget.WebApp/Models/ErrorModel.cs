using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Budget.WebApp.Models
{
    public class ErrorModel
    {
        public string ErrorMessage { get; set; }
        public bool Handled { get; set; }

        public ErrorModel(string message)
        {
            this.ErrorMessage = message;
            this.Handled = true;
        }
    }
}