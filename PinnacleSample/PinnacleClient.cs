using PinnacleSample.Interfaces;

namespace PinnacleSample
{

    public class PinnacleClient
    {
        private IPartInvoiceController __Controller;

        public PinnacleClient() : this(new DataService()) { }

        public PinnacleClient(IDataService services)
        {
            __Controller = new PartInvoiceController(services);
        }

        public CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, string customerName)
        {
            return __Controller.CreatePartInvoice(stockCode, quantity, customerName);
        }
    }
}
