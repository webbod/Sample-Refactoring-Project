namespace PinnacleSample.Interfaces
{
    public interface ICustomerService
    {
        Customer GetByName(string name);
    }
}