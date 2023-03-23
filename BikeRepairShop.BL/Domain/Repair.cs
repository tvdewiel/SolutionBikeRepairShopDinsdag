using BikeRepairShop.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.BL.Domain
{
    public class Repair
    {
        public Repair(Bike bike)
        {
            Bike = bike;
        }
        public Repair(int? id, Bike bike, List<RepairTask> repairTasks) : this(bike)
        {
            Id = id;
            //Bike = bike;
            this.repairTasks = repairTasks;
        }
        public int? Id { get;private set; }
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

        public override bool Equals(object? obj)
        {

            if (obj is Repair)
            {
                Repair compRepair=(Repair)obj;
                if (Id.HasValue && compRepair.Id.HasValue)
                {
                    if (Id == compRepair.Id) return true; else return false;                    
                }
                else
                {
                    return EqualityComparer<Bike>.Default.Equals(Bike, compRepair.Bike) &&
                    EqualityComparer<List<RepairTask>>.Default.Equals(repairTasks, compRepair.repairTasks);
                }
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id,Bike);
        }
        public void SetId(int id)
        {
            if (id <= 0) throw new DomainException("Repair");
            Id = id;
        }
    }
}
