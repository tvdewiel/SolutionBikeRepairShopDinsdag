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

        public void AddBike(Bike bike)
        {
            try
            {
                string sql = "INSERT INTO Bike(biketype,purchasecost,description,customerid,status) output  INSERTED.ID VALUES(@biketype,@purchasecost,@description,@customerid,@status)";
                using(SqlConnection connection= new SqlConnection(connectionString))
                using(SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@biketype",bike.BikeType.ToString());
                    command.Parameters.AddWithValue("@purchasecost", bike.PurchaseCost);
                    if (bike.Description!= null)
                        command.Parameters.AddWithValue("@description", bike.Description);
                    else
                        command.Parameters.AddWithValue("@description",DBNull.Value);
                    command.Parameters.AddWithValue("@customerid", bike.Customer.ID);
                    command.Parameters.AddWithValue("@status", 1);
                    int bid=(int)command.ExecuteScalar();
                    bike.SetId(bid);
                }
            }
            catch(Exception ex)
            {
                throw new CustomerRepositoryException("AddBike", ex);
            }
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

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}