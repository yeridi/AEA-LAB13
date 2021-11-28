using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITecsup.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string Number { get; set; }
        public int Total { get; set; }

        public List<Detail> Details { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
    }
}