using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.BL.Domain
{
    public class RepairOrder
    {
        public int Id { get;private set; }
        public DateOnly DateIn { get; set; }
        public DateOnly? DateOut { get;private set; }
        public Customer Customer { get; private set; }
        public double Discount { get; private set; }
        public bool Payed { get; private set; }
        public double? CostPayed { get; private set; }
        public Urgency Urgency { get; private set; }
        private List<Repair> repairs = new List<Repair>();
        public void AddRepair(Repair repair)
        {

        }
        public void RemoveRepair(Repair repair)
        {

        }
        public double Cost()
        {
            double cost = 0.0;
            foreach (Repair repair in repairs) cost += repair.Cost();
            cost *= (100 - Discount) / 100;
            if (Customer.GetCustomerRepairOrderInfos().Count > 5) cost *= 0.98;
            switch (Urgency)
            {
                case Urgency.Fast: return cost*1.2;
                case Urgency.Normal:  return cost;
                case Urgency.NoRush: return cost*0.95;
                default: return cost;
            }
        }
        public IReadOnlyList<Repair> Repairs()
        {

        }
    }
}
