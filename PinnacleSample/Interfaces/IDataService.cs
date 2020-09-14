namespace PinnacleSample.Interfaces
{
    public interface IDataService
    {
        ICustomerService CustomerService { get; }
        IPartInvoiceService PartInvoiceService { get; }
        IPartAvailabilityService PartAvaliabilityService { get; }
    }
}
