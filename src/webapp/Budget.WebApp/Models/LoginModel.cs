using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Budget.Resources;

namespace Budget.WebApp.Models
{
    public class LoginModel
    {
        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ThisFieldIsRequired")]
        [Display(ResourceType = typeof(Text), Name = "Username")]
        public string Login { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ThisFieldIsRequired")]
        [Display(ResourceType = typeof(Text), Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}