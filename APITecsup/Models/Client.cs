using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITecsup.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public List<Invoice> Invoices { get; set; }
        
    }
}