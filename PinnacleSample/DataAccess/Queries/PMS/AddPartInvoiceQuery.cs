using System.Data;
using System.Data.SqlClient;

namespace PinnacleSample.DataAccess.Queries.PMS
{
    public class AddPartInvoiceQuery : AGenericQuery<bool>
    {
        public AddPartInvoiceQuery(PartInvoice invoice) : this(invoice.StockCode, invoice.Quantity, invoice.CustomerID)
        {
        }

        public AddPartInvoiceQuery(string stockCode, int quantity, int customerID, string connectionString = null) : base(connectionString)
        {
            __Parameters = new SqlParameter[] {
                new SqlParameter("@StockCode", SqlDbType.VarChar, 50) { Value = stockCode },
                new SqlParameter("@Quantity", SqlDbType.Int) { Value = quantity },
                new SqlParameter("@CustomerID", SqlDbType.Int) { Value = customerID }
            };
        }

        public override void ExecuteNonQuery()
        {
            ExecuteNonQuery("PMS_AddPartInvoice");
        }
    }
}
