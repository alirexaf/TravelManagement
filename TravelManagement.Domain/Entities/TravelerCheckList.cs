using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.Exceptions;
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
        public void AddItem(TravelerItem item)
        {
            //Assuming that two TravelerItems with the same names are equal 
            var alreadyExists = _items.Any(p => p.Name == item.Name);
            if (alreadyExists)
                throw new TravelerItemAlreadyExistsException(_name, item.Name);

            _items.AddLast(item);
        }
        public void AddItems(IEnumerable<TravelerItem> items)
        {
            foreach (var item in items)
                AddItem(item);
        }
        public void TakeItem(string itemName)
        {
            var item = GetItem(itemName);
            var TravelerItem = item with { IsTaken = true };
            _items.Find(item).Value = TravelerItem;
        }
        public void RemoveItem(string itemName)
        {
            var item = GetItem(itemName);
            _items.Remove(item);
        }
        private TravelerItem GetItem(string itemName)
        {
            var item = _items.SingleOrDefault(p => p.Name == itemName);
            if (item is null)
                throw new TravelerItemNotFoundException(itemName);
            return item;
        }
    }
}
