using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Budget.Resources;

namespace Budget.WebApp.Models
{
    public class AddReceiptEntryModel
    {
        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ThisFieldIsRequired")]
        [Display(ResourceType = typeof(Text), Name = "Amount")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
    }
}