using PinnacleSample.Tests.Helpers;
using PinnacleSample.Tests.Mocks.Services;
using Xunit;

namespace PinnacleSample.Tests
{
    public class PinnacleClient
    {
        private PinnacleSample.PinnacleClient __Client = new PinnacleSample.PinnacleClient(new MockDataService());

        [Theory]
        [InlineData("Evertyhing is valid", true, MockPartAvailabilityService.ProductWithHighStockLevel, MockPartAvailabilityService.SmallQuantity, MockCustomerServices.ExistingCustomer)]
        [InlineData("Customer is not recognised", false, MockPartAvailabilityService.ProductWithHighStockLevel, MockPartAvailabilityService.SmallQuantity, MockCustomerServices.NonExistantCustomer)]       
        [InlineData("There is just enough in stock", true, MockPartAvailabilityService.ProductWithLowStockLevel, MockPartAvailabilityService.SmallQuantity, MockCustomerServices.ExistingCustomer)]
        [InlineData("There is not enough in stock", false, MockPartAvailabilityService.ProductWithLowStockLevel, MockPartAvailabilityService.LargeQuantity, MockCustomerServices.ExistingCustomer)]
        [InlineData("Product is out of stock", false, MockPartAvailabilityService.ProductThatIsOutOfStock, MockPartAvailabilityService.SmallQuantity, MockCustomerServices.ExistingCustomer)]
        [InlineData("Order quantity is invalid", false, MockPartAvailabilityService.ProductWithLowStockLevel, MockPartAvailabilityService.Empty, MockCustomerServices.ExistingCustomer)]
        [InlineData("Product is not recognised", false, MockPartAvailabilityService.UnknownProduct, MockPartAvailabilityService.SmallQuantity, MockCustomerServices.ExistingCustomer)]
        
        public void Test(string scenario, bool expected, string stockCode, int quantity, string customerName )
        {
            // there are no side-effects, so it's OK to re-cycle __Client
            var _Actual = __Client.CreatePartInvoice(stockCode, quantity, customerName);

            CustomAssert.Equal<bool>(expected, _Actual.Success, scenario);
        }

    }
}
