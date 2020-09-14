namespace PinnacleSample.Interfaces
{
    public interface IPartInvoiceController
    {
        CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, string customerName);
    }
}