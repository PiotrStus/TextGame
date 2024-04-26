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
        public string Description { get; protected set; }
        public void GetDescription()
        {
            Console.WriteLine($"{Description}");
        }
        public void AddItem(Item newItem)
        {
            AvailableItems.Add(newItem);
        }
        public void RemoveItem(Witcher geralt)
        {
            int numberOfItems = AvailableItems.Count;
            if (numberOfItems > 0)
            {
                int i = 0;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("You can choose:\n");
                foreach (Item item in AvailableItems)
                {
                    Console.WriteLine($"{i + 1}) {item.Description}");
                    i++;
                }
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("\nWhich of the items should I take?" +
                $"\n\nChoose a number{(numberOfItems > 1 ? " from '1' to" : "")} '{numberOfItems}': ");
                if (int.TryParse(Console.ReadLine(), out int choosenNumber) && choosenNumber <= numberOfItems && choosenNumber > 0)
                {
                    Item choosenItem = AvailableItems[choosenNumber - 1];
                    AvailableItems.RemoveAt(choosenNumber - 1);
                    geralt.ReceiveItems(choosenItem);
                }
                else Console.WriteLine("That's not a correct number.");
                Console.Clear();
            }
            else
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("There are no items here.");
                Console.WriteLine("-----------------------------------------------\n");
            }
        }
        public void ShowItems()
        {
            int numberOfItems = AvailableItems.Count;
            if (numberOfItems > 0)
            {
                Console.WriteLine($"All the items you can find in the location - {Name}: \n");
                int i = 0;
                foreach (var item in AvailableItems)
                {
                    {
                        if (item is Sword)
                        {
                            Sword sword = (Sword)item;
                            Console.WriteLine($"{i + 1}) {sword.Description} - {sword.Kind} sword");
                        }
                        else
                        {
                            Console.WriteLine($"{i + 1}) {item.Description}");
                        }
                    }
                    i++;
                }
            }
            else Console.WriteLine("There are no items here.");
        }
        abstract protected void AddItems();
        abstract protected void AddDescription();
    }
}
