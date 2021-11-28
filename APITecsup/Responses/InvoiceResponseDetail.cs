using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITecsup.Responses
{
    public class InvoiceResponseDetail
    {
        public int Count { get; set; }
        public int Price { get; set; }
        public int SubTotal { get; set; }
        public double Igv { get; set; }
        public double Total { get; set; }
    }
}