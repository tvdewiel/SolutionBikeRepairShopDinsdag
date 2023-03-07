using BikeRepairShop.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.BL.Domain
{
    public class Bike
    {
        public Bike(string? description, double purchaseCost, BikeType bikeType)
        {
            Description = description;
            PurchaseCost = purchaseCost;
            BikeType = bikeType;
        }

        public Bike(int? iD, string? description, double purchaseCost, BikeType bikeType)
        {
            ID = iD;
            Description = description;
            PurchaseCost = purchaseCost;
            BikeType = bikeType;
        }

        public int? ID { get; private set; }
        public string? Description { get; set; }
        public double PurchaseCost { get; private set; }
        public BikeType BikeType { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Bike bike &&
                   Description == bike.Description &&
                   PurchaseCost == bike.PurchaseCost &&
                   BikeType == bike.BikeType;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Description, PurchaseCost, BikeType);
        }

        public void SetId(int id)
        {
            if (id <= 0) throw new DomainException("bike-setid");
            ID = id;
        }
        public void SetPurchaseCost(double cost)
        {
            if (cost <= 0) throw new DomainException("Bike-setpurchasecost");
            PurchaseCost = cost;
        }
    }
}
