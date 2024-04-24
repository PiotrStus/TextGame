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
    }
}
