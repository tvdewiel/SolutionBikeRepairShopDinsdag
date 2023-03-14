using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.BL.Domain
{
    public class Repairman
    {
        public int Id { get;private set; }
        public string Name { get; private set; }
        public double CostPerHour { get; private set; }
        public string Email { get; private set; }
    }
}
