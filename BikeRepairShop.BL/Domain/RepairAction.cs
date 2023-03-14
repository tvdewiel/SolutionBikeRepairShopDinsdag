using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.BL.Domain
{
    public class RepairAction
    {
        public int Id { get;private set; }
        public string Description { get; set; }
        public int RepairTime { get;private set; } //minutes
        public double MaterialCost { get;private set; }
    }
}
