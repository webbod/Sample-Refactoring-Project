namespace PinnacleSample
{
    public static class PartAvailabilityService_Extensions
    {
        /// <summary>
        /// Checks to see if enough of the product is in stock
        /// - this was originally only checking if something was in stock, 
        //  - but that didn't seem like the correct behaviour
        /// </summary>
        /// <param name="stockCode">stock code</param>
        /// <param name="minimumQuanitity">minimum quantity required</param>
        /// <returns></returns>
        public static bool EnoughOfTheProductIsInStock(this IPartAvailabilityService client, string stockCode, int minimumQuanitity = 0)
        {
            return client.GetAvailability(stockCode) >= minimumQuanitity;
        }

        // Reason for using an extension:
        // 1. This is a bit of business logic that is tightly coupled to the PartAvailabilityServiceClient class
        // 2. PartAvailabilityServiceClient is a partial class, but any new functionaly would have to be re-created in a mocked client
        // 3. IPartAvailabilityService is not a partial class, so a new interface would be needed to expose the EnoughOfTheProductIsInStock method
        // 3. Binding the extension method to the interface resolves all three issues
    }
}
