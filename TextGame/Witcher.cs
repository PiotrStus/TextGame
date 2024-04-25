using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Items;

namespace TextGame
{
    internal class  Witcher : Character
    {
        public Witcher(string name, int health, List<Item> items) : base(name, health, items) 
        { 

        }

        public override string ToString()
        {
            return Name;
        }

        public override void ShowCurrentHealth()
        {
            Console.WriteLine($"My current health is: {Health}%.");
        }

        public void ShowItems()
        {
            Console.WriteLine("That's all what I can use: \n");
            foreach (var item in Items)
            {
                
                if (item is Sword )
                { 
                    Sword sword = (Sword)item;
                    Console.WriteLine($"{sword.Description} - {sword.Kind} sword");
                }
                else
                {
                    Console.WriteLine($"{item.Description}");
                }
            }
        }
    }
}
