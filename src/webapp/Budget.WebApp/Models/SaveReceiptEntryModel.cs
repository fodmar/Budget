using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Budget.ObjectModel;
using Budget.Resources;

namespace Budget.WebApp.Models
{
    public class SaveReceiptEntryModel
    {
        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ThisFieldIsRequired")]
        [Display(ResourceType = typeof(Text), Name = "Amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ThisFieldIsRequired")]
        [Display(ResourceType = typeof(Text), Name = "Product")]
        public Product Product { get; set; }
    }
}