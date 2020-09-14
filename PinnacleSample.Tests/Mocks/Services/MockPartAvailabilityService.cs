namespace PinnacleSample.Tests.Mocks.Services
{
    public class MockPartAvailabilityService : IPartAvailabilityService
    {
        public const string ProductWithHighStockLevel = "high";
        public const string ProductWithLowStockLevel = "low";
        public const string ProductThatIsOutOfStock = "none";
        public const string UnknownProduct = "unknown";

        public const int VeryLargeQuantity = 100;
        public const int LargeQuantity = 10;
        public const int SmallQuantity = 1;
        public const int Empty = 0;

        public int GetAvailability(string StockCode)
        {
            switch (StockCode)
            {
                case "high":
                    return LargeQuantity;
                case "low":
                    return SmallQuantity;
                default:
                    return Empty;
            }
        }
    }
}
