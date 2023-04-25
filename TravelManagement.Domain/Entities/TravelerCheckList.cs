using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Domain;

namespace TravelManagement.Domain.Entities
{
    public class TravelerCheckList : AggregateRoot<TravelerCheckListId>
    {
        public TravelerCheckListId Id { get; private set; }
        private TravelerCheckListName _name;
        private TravelerCheckListDestination _destination;
        private readonly LinkedList<TravelerItem> _items = new();

        internal TravelerCheckList(TravelerCheckListId id, 
            TravelerCheckListName name, TravelerCheckListDestination destination)
        {
            Id = id;
            _name = name;
            _destination = destination;
        }
        private TravelerCheckList(
            TravelerCheckListId id,
            TravelerCheckListName name, 
            TravelerCheckListDestination destination, 
            LinkedList<TravelerItem> items) 
            : this(id, name, destination) 
        {
            _items = items;
        }
        public TravelerCheckList()
        {

        }
    }
}
