using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Budget.ObjectModel;

namespace Budget.WebApp.Models.Json
{
    public class FullcalendarEvent
    {
        public int id;
        public DateTime start;
        public string title;

        public FullcalendarEvent(Receipt receipt)
        {
            id = receipt.Id;
            start = receipt.Date;
            title = receipt.Entries.Sum(e => e.Amount).ToString();
        }
    }
}