using TravelManagement.Domain.Entities;
using TravelManagement.Domain.Policies;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Factories
{
    public sealed class TravelerChecklistFactory : ITravelerChecklistFactory
    {
        private readonly IEnumerable<ITravelerItemsPolicy> _policies;
        public TravelerChecklistFactory(IEnumerable<ITravelerItemsPolicy> policies)
            => _policies = policies;
        public TravelerCheckList Create(TravelerCheckListId id, TravelerCheckListName name, 
            TravelerCheckListDestination destination) => new(id, name, destination);
        public TravelerCheckList CreateWithDefaultItems(TravelerCheckListId id, TravelerCheckListName name, TravelDays days,
            Consts.Gender gender, Temperature temperature, TravelerCheckListDestination destination)
        {
            var data = new PolicyData(days, gender, temperature, destination);
            var applicablePolicies = _policies.Where(p => p.IsApplicable(data));
            
            var items =  applicablePolicies.SelectMany(p => p.GenerateItems(data));
            var travelerChecklist = Create(id, name, destination);

            travelerChecklist.AddItems(items);
            return travelerChecklist;
        }
    }
}
