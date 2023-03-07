using BikeRepairShop.BL.Domain;
using BikeRepairShop.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.BL.Interfaces
{
    public interface ICustomerRepository
    {
        void AddBike(Bike bike);
        List<BikeInfo> GetBikesInfo();
        Customer GetCustomer(int id);
    }
}
