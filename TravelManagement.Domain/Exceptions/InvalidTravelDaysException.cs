using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Domain.Exceptions
{
    public class InvalidTravelDaysException : Exception
    {
        public ushort Value { get;}
        public InvalidTravelDaysException(ushort value) : base($"Value {value} is invalid for TravelDays.")
            =>  Value = value;
    }
}
