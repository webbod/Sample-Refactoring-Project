using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PinnacleSample.DataAccess.Queries.CRM
{
    public class GetCustomerByName : AGenericQuery<Customer>
    {
        public GetCustomerByName(string name, string connectionString = null) : base(connectionString)
        {
            __Parameters = new SqlParameter[] {
                new SqlParameter("@Name", SqlDbType.NVarChar) { Value = name }
            };
        }

        public override Customer ExecuteQuery()
        {
            return ExecuteQuery("CRM_GetCustomerByName")?.FirstOrDefault();
        }

        public override Customer Mapper(IDataRecord reader)
        {
            return new Customer
            {
                ID = int.Parse(reader["CustomerID"].ToString()),
                Name = reader["Name"].ToString(),
                Address = reader["Address"].ToString()
            };
        }
    }
}
