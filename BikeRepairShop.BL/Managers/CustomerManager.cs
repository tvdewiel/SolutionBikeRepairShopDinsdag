using BikeRepairShop.BL.Domain;
using BikeRepairShop.BL.DTO;
using BikeRepairShop.BL.Exceptions;
using BikeRepairShop.BL.Factories;
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
        public void AddBike(BikeInfo bikeInfo)
        {
            try {
                //Customer customer = repo.GetCustomer(bikeInfo.Customer.id);
                Bike bike = DomainFactory.NewBike(bikeInfo);
                //customer.AddBike(bike);
                repo.AddBike(bike);
                bikeInfo.Id=bike.ID;
            }
            catch(Exception ex) { throw new ManagerException("AddBike", ex); }
        }
    }
}
