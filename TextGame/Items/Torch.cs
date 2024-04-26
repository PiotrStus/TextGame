﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Items
{
    internal class Torch : Item
    {
        public Torch(string description) : base(description)
        {
        }
        public override void Use()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("There was light (although I don't need it I can see in dark :-) )");
            Console.WriteLine("-----------------------------------------------\n");
        }
    }
}
