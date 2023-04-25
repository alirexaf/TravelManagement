using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Domain.ValueObjects
{
    public record TravelerCheckListDestination(string City, string Country)
    {
        public static TravelerCheckListDestination Create(string value)
        {
            var splitDestination = value.Split(',');
            return new TravelerCheckListDestination(splitDestination.First(), 
                splitDestination.Last());

        }
        public override string ToString() => $"{City}, {Country}";

    }
}
