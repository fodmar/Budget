using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Budget.ObjectModel;
using Budget.Resources;
using Budget.WebApp.Attributes;

namespace Budget.WebApp.Models
{
    public class SaveReceiptModel
    {
        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ThisFieldIsRequired")]
        [Display(ResourceType = typeof(Text), Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [NotEmpty]
        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ThisFieldIsRequired")]
        public SaveReceiptEntryModel[] Entries { get; set; }

        public Receipt ToReceipt(int userId)
        {
            Receipt result = new Receipt();
            result.Date = this.Date;
            result.UserId = userId;

            result.Entries = this.Entries.Select(e => new ReceiptEntry()
            {
                Amount = e.Amount,
                ProductId = e.ProductId
            }).ToArray();

            return result;
        }
    }
}