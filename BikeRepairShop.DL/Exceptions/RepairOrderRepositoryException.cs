using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.DL.Exceptions
{
    public class RepairOrderRepositoryException : Exception
    {
        public RepairOrderRepositoryException(string? message) : base(message)
        {
        }

        public RepairOrderRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
