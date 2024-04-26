using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Items
{
    internal class Item : IAction
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
        public virtual void Use()
        {
            Console.WriteLine("Use an item");
        }
    }
}
