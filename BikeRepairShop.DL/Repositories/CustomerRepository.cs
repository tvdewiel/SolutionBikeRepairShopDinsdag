using BikeRepairShop.BL.DTO;
using BikeRepairShop.BL.Interfaces;

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

        }
    }
}