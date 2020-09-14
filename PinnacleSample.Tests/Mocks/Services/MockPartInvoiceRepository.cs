using PinnacleSample.Interfaces;
using System;

namespace PinnacleSample.Tests.Mocks.Services
{
    public class MockPartInvoiceRepository : IPartInvoiceService
    {
        public void Add(PartInvoice invoice)
        {
            if(invoice == null)
            {
                throw new ArgumentException();
            }
        }

        public void Add(string stockCode, int quantity, Customer customer)
        {
            
        }
    }
}
