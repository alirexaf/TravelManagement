using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.Consts;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Factories
{
    public interface ITravelerChecklistFactory
    {
        TravelerCheckList Create(TravelerCheckListId id, TravelerCheckListName name, TravelerCheckListDestination destination);
        TravelerCheckList CreateWithDefaultItems(TravelerCheckListId id, TravelerCheckListName name, TravelDays days, 
            Consts.Gender gender, Temperature temperature, TravelerCheckListDestination destination);
    }
}
