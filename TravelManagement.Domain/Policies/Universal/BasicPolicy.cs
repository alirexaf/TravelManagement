using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Policies.Universal
{
    internal sealed class BasicPolicy : ITravelerItemsPolicy
    {
        private const uint MAXIMUM_PIECES_OF_CLOTHES = 7;
        public bool IsApplicable(PolicyData _)
            => true;

        public IEnumerable<TravelerItem> GenerateItems(PolicyData data)
            => new List<TravelerItem>
            {
                new("Pants", Math.Min(data.Days, MAXIMUM_PIECES_OF_CLOTHES)),
                new("Socks", Math.Min(data.Days, MAXIMUM_PIECES_OF_CLOTHES)),
                new("T-Shirt", Math.Min(data.Days, MAXIMUM_PIECES_OF_CLOTHES)),
                new("Trousers", data.Days < 7 ? 1u : 2u),
                new("Shampoo", 1),
                new("Toothbrush", 1),
                new("Toothpaste", 1),
                new("Towel", 1),
                new("Backpack", 1),
                new("Passport", 1),
                new("Phone charger", 1),
            };

    }
}
