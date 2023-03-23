using BikeRepairShop.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.BL.Domain
{
    public class RepairTask
    {
        public RepairTask(int? id, RepairAction repairAction, Repairman repairman)
        {
            Id = id;
            RepairAction = repairAction;
            Repairman = repairman;
        }

        public int? Id { get;private set; }
        public RepairAction RepairAction { get; set; }
        public Repairman Repairman { get; set; }
        public double Cost()
        {
            return RepairAction.RepairTime*Repairman.CostPerHour / 60.0 + RepairAction.MaterialCost;
        }
        public void SetId(int id)
        {
            if (id <= 0) throw new DomainException("RepairTask");
            Id = id;
        }
    }
}
