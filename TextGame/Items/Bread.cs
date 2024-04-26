using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Items
{
    internal class Bread : Item, IAction
    {
        public Bread(string description) : base(description)
        {
        }
        public override void Use()
        {
            string outro = "What a delicious bread :-)" +
            "\nFinally I found some place to rest..." +
            "\nIt's going to be a very long day tomorrow..." +
            "\nSee you on a trail again...";
            Console.WriteLine("-----------------------------------------------");
            foreach (char c in outro)
            {
                Console.Write(c);
                Thread.Sleep(30);
            }
            Console.WriteLine("\n-----------------------------------------------");
        }
    }
}
