using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Items
{
    internal class Item
    {
        public Item(string description)
        {
            Description = description;
        }
        public string? Description { get; private set; }
        public void ItemInfo()
        {
            Console.WriteLine($"This is {Description}");
        }

        public void Use()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Item used");
            Console.WriteLine("-----------------------------------------------\n");
        }
    }
}
