using BikeRepairShop.BL.Domain;
using BikeRepairShop.BL.DTO;
using BikeRepairShop.BL.Interfaces;
using BikeRepairShop.DL.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace BikeRepairShop.DL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private string connectionString;

        public CustomerRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<BikeInfo> GetBikesInfo()
        {
            try
            {
                List<BikeInfo> bikes=new List<BikeInfo>();
                string sql = "select t1.*,t2.name,t2.email from bike t1 inner join customer t2 on t1.CustomerId=t2.Id where t1.Status=1 and t2.Status=1";
                using(SqlConnection connection = new SqlConnection(connectionString))
                using(SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = sql;
                    IDataReader reader= command.ExecuteReader();
                    while(reader.Read())
                    {
                        //string d=reader.IsDBNull(reader.GetOrdinal("description")) ? null : (string)reader["description"];
                        //Enum.Parse(typeof(BikeType), (string)reader["biketype"], true);
                        bikes.Add(new BikeInfo((int)reader["id"], reader.IsDBNull(reader.GetOrdinal("description")) ? null : (string)reader["description"],(BikeType) Enum.Parse(typeof(BikeType), (string)reader["biketype"], true), (double)reader["purchasecost"], (int)reader["customerid"], (string)reader["name"]+" (" + (string)reader["email"]+")"));
                    }
                    reader.Close();
                }                
                return bikes;
            }
            catch(Exception ex)
            {
                throw new CustomerRepositoryException("GetBikesInfo", ex);
            }
        }
    }
}