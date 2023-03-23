using BikeRepairShop.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.BL.Domain
{
    public class RepairOrder
    {
        public int? Id { get;private set; }
        public DateOnly DateIn { get; set; }
        public DateOnly? DateOut { get;private set; }
        public Customer Customer { get; private set; }
        public double Discount { get; private set; }
        public bool Payed { get; private set; }
        public double? CostPayed { get; private set; }
        public Urgency Urgency { get; private set; }
        private List<Repair> repairs = new List<Repair>();

        public RepairOrder(DateOnly dateIn, DateOnly? dateOut, Customer customer, double discount, bool payed, double? costPayed, Urgency urgency)
        {
            DateIn = dateIn;
            DateOut = dateOut;
            Customer = customer;
            Discount = discount;
            Payed = payed;
            CostPayed = costPayed;
            Urgency = urgency;
        }

        public RepairOrder(int? id, DateOnly dateIn, DateOnly? dateOut, Customer customer, double discount, bool payed, double? costPayed, Urgency urgency, List<Repair> repairs)
        {
            Id = id;
            DateIn = dateIn;
            DateOut = dateOut;
            Customer = customer;
            Discount = discount;
            Payed = payed;
            CostPayed = costPayed;
            Urgency = urgency;
            this.repairs = repairs;
        }

        public void AddRepair(Repair repair)
        {
            if (repair == null) throw new DomainException("AddRepair");
            if (repairs.Contains(repair)) throw new DomainException("AddRepair");
            repairs.Add(repair);
        }
        public void RemoveRepair(Repair repair)
        {
            if (repair == null) throw new DomainException("RemoveRepair");
            if (!repairs.Contains(repair)) throw new DomainException("RemoveRepair");
            repairs.Remove(repair);
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
            return repairs.AsReadOnly();
        }
        public void SetId(int id)
        {
            if (id <= 0) throw new DomainException("RepairOrder");
            Id = id;
        }
    }
}
