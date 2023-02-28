using BikeRepairShop.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.BL.DTO
{
    public class BikeInfo
    {
        public BikeInfo(int id, string description, BikeType bikeType, double purchaseCost, int customerId, string customerDescription)
        {
            Id = id;
            Description = description;
            BikeType = bikeType;
            PurchaseCost = purchaseCost;
            Customer = (customerId,customerDescription);
        }

        public int Id { get; set; } //bikeID
        public string Description { get; set; }
        public BikeType BikeType { get; set; }
        public double PurchaseCost { get; set; }
        public (int id, string description) Customer { get; set; }
    }
}
