using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Items;

namespace TextGame
{
    internal class Witcher : Character
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
            int i = 1;
            foreach (var item in Items)
            {
                if (item is Sword)
                {
                    Sword sword = (Sword)item;
                    Console.WriteLine($"{i}) {sword.Description} - {sword.Kind} sword");
                }
                else
                {
                    Console.WriteLine($"{i}) {item.Description}");
                }
                i++;
            }
        }
        public void UseItem()
        {
            int numberOfItems = Items.Count;
            if (numberOfItems > 0)
            {
                int i = 0;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("You can choose:\n");
                foreach (Item item in Items)
                {
                    Console.WriteLine($"{i + 1}) {item.Description}");
                    i++;
                }
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("\nWhich of the items should I use?" +
                $"\n\nChoose a number{(numberOfItems > 1 ? " from '1' to" : "")} '{numberOfItems}': ");
                if (int.TryParse(Console.ReadLine(), out int choosenNumber) && choosenNumber <= numberOfItems && choosenNumber > 0)
                {
                    Console.Clear();
                    if (Items[choosenNumber - 1] is Sword)
                    {
                        Sword sword = (Sword)Items[choosenNumber - 1];
                        sword.Use();
                    }
                    else if (Items[choosenNumber - 1] is Torch)
                    {
                        Torch torch = (Torch)Items[choosenNumber - 1];
                        torch.Use();
                    }
                    else if (Items[choosenNumber - 1] is Bread)
                    {
                        Bread bread = (Bread)Items[choosenNumber - 1];
                        bread.Use();
                        IncreaseHealth(20);
                        ShowCurrentHealth();
                    }
                    else Items[choosenNumber - 1].Use();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine("That's not a correct number.");
                    Console.WriteLine("-----------------------------------------------\n");
                }
            }
            else
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("There are no items here.");
                Console.WriteLine("-----------------------------------------------\n");
            }
        }
        public void ReceiveItems(Item item)
        {
            Items.Add(item);
        }
    }
}
