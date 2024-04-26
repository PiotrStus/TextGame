using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Items
{
    internal class Sword : Item, IAction
    {
        public Sword(string description, string kind) : base(description)
        {
            Kind = kind;
        }
        public string Kind { get; private set; }
        public void Use()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Damage dealt");
            Console.WriteLine("-----------------------------------------------\n");
        }
    }
}
