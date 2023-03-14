using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.BL.Domain
{
    public class Repair
    {
        public int Id { get;private set; }
        public Bike Bike { get; private set; }
        private List<RepairTask> repairTasks = new List<RepairTask>();
        public IReadOnlyList<RepairTask> RepairTasks() { return repairTasks.AsReadOnly(); }
        public void AddRepairTask(RepairTask repairTask) { }
        public void RemoveRepairTask(RepairTask repairTask) { }
        public double Cost()
        {
            double cost = 0.0;
            foreach(RepairTask task in repairTasks) cost+= task.Cost();
            return cost;
        }
    }
}
