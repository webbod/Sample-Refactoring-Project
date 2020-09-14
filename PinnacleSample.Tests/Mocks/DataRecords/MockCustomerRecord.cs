namespace PinnacleSample.Tests.Mocks.DataRecords
{
    public class MockCustomerRecord : AMockDataRecord
    {
        public MockCustomerRecord(Customer customer)
        {
            // the keys need to match the field names returned by the query
            SetValue("CustomerID", customer.ID);
            SetValue("Name", customer.Name);
            SetValue("Address", customer.Address);
        }
    }
}
