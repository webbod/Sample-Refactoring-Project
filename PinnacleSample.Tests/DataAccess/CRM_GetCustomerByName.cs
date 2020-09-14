using PinnacleSample.DataAccess.Queries.CRM;
using PinnacleSample.Tests.Mocks.DataRecords;
using Xunit;

namespace PinnacleSample.Tests.DataAccess
{
    public class CRM_GetCustomerByName
    {
        [Fact]
        public void TestThatTheMapperIsWorking()
        {
            var _Query = new GetCustomerByName(string.Empty);

            var _Expected = new Customer
            {
                ID = 1001,
                Name = "John Smith",
                Address = "101 Street, City, P05 7DE"
            };

            var _Actual = _Query.Mapper(new MockCustomerRecord(_Expected));

            Assert.Equal(_Expected.Name, _Actual.Name);
            Assert.Equal(_Expected.Address, _Actual.Address);
            Assert.Equal(_Expected.ID, _Actual.ID);

            // this is just to prove that the objects are physically different
            Assert.NotEqual(_Expected, _Actual);
        }

    }
}
