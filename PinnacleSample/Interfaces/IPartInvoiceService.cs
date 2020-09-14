namespace PinnacleSample.Interfaces
{
    public interface IPartInvoiceService
    {
        void Add(PartInvoice invoice);
        void Add(string stockCode, int quantity, Customer customer);
    }
}