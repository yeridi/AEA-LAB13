using APITecsup.Context;
using APITecsup.Models;
using APITecsup.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APITecsup.Controllers
{
    public class InvoicesController : ApiController
    {
        private ExampleContext db = new ExampleContext();
        
        [HttpPost]
        public InvoiceResponse Insert(Invoice request)
        {           
            db.Invoices.Add(request);
            db.SaveChanges();
            Client client = db.Clients.Find(request.ClientID);
            var response = new InvoiceResponse
            {
                InvoiceID = request.InvoiceID,
                Number = request.Number,
                ClientName = client.Name
            };
            return response;
        }

        [HttpGet]
        public List<InvoiceResponseV2> GetByPrice(int MinPrice, int MaxPrice )
        {
            var invoices = db.Invoices.
                Where(x => x.Total > MinPrice && x.Total < MaxPrice)
                .ToList();

            var response = (from c in invoices
                           select new InvoiceResponseV2
                           {
                               Number = c.Number,
                               Total = c.Total
                           }).ToList();
            return response;
        }

        [HttpGet]
        public List<InvoiceResponseDetail> getDetails (string Number)
        {
           var invoices = db.Invoices.Include("Details")
                .Where(i => i.Number == Number).ToList();
            if (invoices.Count == 0)
            {
                return null;
            }
            var invoice = invoices.First();
            var response = (from d in invoice.Details
                            select new InvoiceResponseDetail
                            {
                                Count = d.Count,
                                Igv = d.Igv,
                                Price = d.Price,
                                SubTotal = d.SubTotal,
                                Total = d.Total

                            }).ToList();
            return response;
        }

    }
}
