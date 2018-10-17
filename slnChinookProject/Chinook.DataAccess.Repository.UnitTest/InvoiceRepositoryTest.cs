using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Chinook.DataAccess.Repository.Interfaces;
using Chinook.Entities.Base;
using System.Linq;

namespace Chinook.DataAccess.Repository.UnitTest
{
    /// <summary>
    /// Descripción resumida de InvoiceRepositoryTest
    /// </summary>
    [TestClass]
    public class InvoiceRepositoryTest
    {
        private readonly DbContext dbContext;
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IUnitOfWork unitOfWork;

        public InvoiceRepositoryTest()
        {
            dbContext = new ChinookDBModel();
            unitOfWork = new UnitOfWork(dbContext);
        }

        [TestMethod]
        public void AddInvoice()
        {
            var invoice = new Invoice();
            invoice.CustomerId = 2;
            invoice.InvoiceDate = DateTime.Now;
            invoice.BillingCity = "San Juan de Miraflores";
            invoice.BillingAddress = "Pj. Los Lirios 1234";
            invoice.BillingCountry = "Perú";
            invoice.BillingPostalCode = "Lima 29";

            invoice.InvoiceLine = new List<InvoiceLine>();
            //Item1
            invoice.InvoiceLine.Add(
                new InvoiceLine()
                {
                    TrackId = 1 ,
                    Quantity = 2,
                    UnitPrice = 10
                });
            //Item2
            invoice.InvoiceLine.Add(
                new InvoiceLine()
                {
                    TrackId = 2,
                    Quantity = 3,
                    UnitPrice = 10
                });

            invoice.Total = invoice.InvoiceLine
                .Sum(item => item.UnitPrice * item.Quantity);

            unitOfWork.InvoiceRepository.Add(invoice);
            unitOfWork.Complete();
            unitOfWork.Dispose();

            Assert.IsTrue(invoice.InvoiceId > 0, "OK");
        }
    }
}
