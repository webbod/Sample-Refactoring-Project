using PinnacleSample.DataAccess.Queries.CRM;
using PinnacleSample.Interfaces;

namespace PinnacleSample
{
    public class CustomerRepositoryDB : ICustomerService
    {
        public Customer GetByName(string name)
        {
            return new GetCustomerByName(name).ExecuteQuery();
        }
    }
}
