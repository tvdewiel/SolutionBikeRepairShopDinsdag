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
        List<BikeInfo> GetBikesInfo();
    }
}
