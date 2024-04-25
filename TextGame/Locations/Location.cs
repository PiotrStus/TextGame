using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Items;

namespace TextGame.Locations
{
    internal abstract class Location
    {
        public Location(LocationsNames name)
        {
            Name = name;
        }
        public List<Item> AvailableItems { get; protected set; } = new List<Item>();
        public LocationsNames Name { get; private set; }

        public List<string> Items { get; private set; }

        public string Description { get; protected set; }

        public void GetDescription()
        {
            Console.WriteLine($"{Description}");
        }

        public void AddItem(Item newItem)
        {

        }

        abstract protected void AddItems();
        abstract protected void ChangeLocationsOptions();
        abstract protected void AddDescription();
    }
}
