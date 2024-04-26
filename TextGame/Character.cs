using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Items;

namespace TextGame
{
    internal class Character
    {
        public string? Name { get; private set; }
        private const int MAX_HEALTH = 100;
        public int Health { get; private set; }
        public Character(string? name, int health, List<Item> items)
        {
            Name = name;
            Health = health;
            Items = items;
        }
        public List<Item> Items { get; private set; }
        public virtual void ShowCurrentHealth()
        {
            Console.WriteLine("Showing current health");
        }
        public void IncreaseHealth(int healthAdded)
        {
            Health += healthAdded;
            if (Health > MAX_HEALTH)
            {
                Health = MAX_HEALTH;
            }
            Console.WriteLine($"\n\nYour health increased by {healthAdded} points.");
        }
    }
}
