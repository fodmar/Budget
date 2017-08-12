using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Budget.ObjectModel;
using Budget.Resources;

namespace Budget.WebApp.Models
{
    public class AddReceiptModel
    {
        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ThisFieldIsRequired")]
        [Display(ResourceType = typeof(Text), Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public AddReceiptEntryModel[] Entires { get; set; }
    }
}