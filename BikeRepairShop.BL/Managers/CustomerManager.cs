using BikeRepairShop.BL.DTO;
using BikeRepairShop.BL.Exceptions;
using BikeRepairShop.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.BL.Managers
{
    public class CustomerManager
    {
        private ICustomerRepository repo;

        public CustomerManager(ICustomerRepository repo)
        {
            this.repo = repo;
        }

        public List<BikeInfo> GetBikesInfo()
        {
            try
            {
                return repo.GetBikesInfo();
            }
            catch(Exception ex) { throw new ManagerException("GetBikesInfo",ex); }
        }
    }
}
