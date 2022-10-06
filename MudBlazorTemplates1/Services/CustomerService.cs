using Dapper;
using Customer.Data;
using MudBlazor.Charts;
using Npgsql;

namespace Customer.Services
{
    public interface ICustomerService
    {
        List<Ccustomer> GetAllCustomer();
    }

    public class CustomerService : ICustomerService
    {
        public List<Ccustomer> GetAllCustomer()
        {
            List<Ccustomer> Res = new List<Ccustomer>();
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(GbVer.ConnectionString))
                {
                    con.Open();
                    string SQL = "select * from customer order by name1";
                    Res = con.Query<Ccustomer>(SQL).ToList();
                }
            }
            catch (Exception ex)
            {}
            return Res;
        }
    }
}
