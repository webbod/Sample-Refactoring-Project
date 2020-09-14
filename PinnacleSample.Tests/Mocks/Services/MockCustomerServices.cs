using PinnacleSample.Interfaces;

namespace PinnacleSample.Tests.Mocks.Services
{
    public class MockCustomerServices : ICustomerService
    {
        public const string ExistingCustomer = "found";
        public const string NonExistantCustomer = "not found";

        public bool CustomerExists(string customerName, out int customerID)
        {
            var _Customer = GetByName(customerName);
            customerID = _Customer.ID;

            return _Customer.Exists;
        }

        public Customer GetByName(string name)
        {
            var id = name == "found" ? 1 : 0;

            return new Customer
            {
                Address = "Test address",
                ID = id,
                Name = name
            };
        }
    }
}
