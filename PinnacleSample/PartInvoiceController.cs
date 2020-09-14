using PinnacleSample.Interfaces;

namespace PinnacleSample
{
    public class PartInvoiceController : IPartInvoiceController
    {
        private IDataService __DataService;

        public PartInvoiceController() : this(new DataService()) { }

        public PartInvoiceController(IDataService services)
        {
            __DataService = services;
        }

        /// <summary>
        /// An order is valid if the customer exists, the quantity is positive and there is enough stock
        /// </summary>
        private bool OrderIsValid(string stockCode, int quantity, Customer customer)
        {
            return
                customer.Exists &&
                quantity > 0 &&
                !string.IsNullOrEmpty(stockCode) &&
                __DataService.PartAvaliabilityService.EnoughOfTheProductIsInStock(stockCode, quantity);
        }

        private CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, Customer customer)
        {
            if (OrderIsValid(stockCode, quantity, customer))
            {
                __DataService.PartInvoiceService.Add(stockCode, quantity, customer);
                return CreatePartInvoiceResult.Successful();
            }
                
            return CreatePartInvoiceResult.Failed(); 
        }

        public CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, string customerName)
        {
            return CreatePartInvoice(stockCode, quantity, __DataService.CustomerService.GetByName(customerName));
        }
    }
}
