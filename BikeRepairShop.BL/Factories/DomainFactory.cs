using BikeRepairShop.BL.Domain;
using BikeRepairShop.BL.DTO;
using BikeRepairShop.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.BL.Factories
{
    public static class DomainFactory
    {
        public static Bike NewBike(BikeInfo bikeInfo)
        {
            try
            {
                return new Bike(bikeInfo.Description, bikeInfo.PurchaseCost, bikeInfo.BikeType);
            }
            catch (Exception ex)
            {
                throw new FactoryException("NewBike", ex);
            }
        }
    }
}
