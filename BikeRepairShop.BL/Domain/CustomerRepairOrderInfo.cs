using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.BL.Domain
{
    public class CustomerRepairOrderInfo
    {
        public CustomerRepairOrderInfo(int repairOrderId, double? cost, bool payed, DateOnly orderDate)
        {
            RepairOrderId = repairOrderId;
            Cost = cost;
            Payed = payed;
            OrderDate = orderDate;
        }

        public int RepairOrderId { get; }
        public double? Cost { get; }
        public bool Payed { get; }
        public DateOnly OrderDate { get; }
    }
}
