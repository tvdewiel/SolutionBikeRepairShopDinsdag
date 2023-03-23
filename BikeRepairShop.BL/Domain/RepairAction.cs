using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.BL.Domain
{
    public class RepairAction
    {
        public RepairAction(int id, string description, int repairTime, double materialCost)
        {
            Id = id;
            Description = description;
            RepairTime = repairTime;
            MaterialCost = materialCost;
        }

        public int Id { get;private set; }
        public string Description { get; set; }
        public int RepairTime { get;private set; } //minutes
        public double MaterialCost { get;private set; }
    }
}
