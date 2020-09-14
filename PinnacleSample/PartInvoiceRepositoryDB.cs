using PinnacleSample.DataAccess.Queries.PMS;
using PinnacleSample.Interfaces;

namespace PinnacleSample
{
    public class PartInvoiceRepositoryDB : IPartInvoiceService
    {
        public void Add(PartInvoice invoice)
        {
            new AddPartInvoiceQuery(invoice).ExecuteQuery();
        }

        /// <summary>
        /// Creates a part invoice and saves it
        /// </summary>
        /// <param name="stockCode">stock code</param>
        /// <param name="quantity">order quantity</param>
        /// <param name="customer">the customer</param>
        public void Add(string stockCode, int quantity, Customer customer)
        {
            Add(new PartInvoice
            {
                StockCode = stockCode,
                Quantity = quantity,
                CustomerID = customer.ID
            });
        }
    }
}
