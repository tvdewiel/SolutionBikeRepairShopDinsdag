using BikeRepairShop.BL.DTO;
using BikeRepairShop.UI.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.UI.Admin.Mappers
{
    public static class BikeMapper
    {
        public static BikeInfo ToDTO(BikeUI bikeUI)
        {
            return new BikeInfo(bikeUI.Id, bikeUI.Description, bikeUI.BikeType, bikeUI.PurchaseCost, bikeUI.CustomerId, bikeUI.CustomerDescription);
        }
    }
}
