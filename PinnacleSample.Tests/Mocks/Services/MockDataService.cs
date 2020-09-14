using PinnacleSample.Interfaces;

namespace PinnacleSample.Tests.Mocks.Services
{
    public class MockDataService : IDataService
    {
        public ICustomerService CustomerService { get; private set; }

        public IPartInvoiceService PartInvoiceService { get; private set; }

        public IPartAvailabilityService PartAvaliabilityService { get; private set; }

        public MockDataService()
        {
            CustomerService = new MockCustomerServices();
            PartInvoiceService = new MockPartInvoiceRepository();
            PartAvaliabilityService = new MockPartAvailabilityService();
        }
    }
}
