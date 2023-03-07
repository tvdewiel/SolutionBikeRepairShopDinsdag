using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.BL.Exceptions
{
    public class FactoryException : Exception
    {
        public FactoryException(string? message) : base(message)
        {
        }

        public FactoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
