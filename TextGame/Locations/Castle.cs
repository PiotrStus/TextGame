using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Items;

namespace TextGame.Locations
{
    internal class Castle : Location
    {
        public Castle() : base(LocationsNames.Castle)
        {
            AddDescription();
            AddItems();
        }
        protected override void AddDescription()
        {
            Description = $"Your current location is an old abandoned: {Name}";
        }
        protected override void AddItems()
        {
            Sword sword1 = new Sword("Barker", "silver");
            AddItem(sword1);
            Sword sword2 = new Sword("Razor power", "silver");
            AddItem(sword2);
            Torch torch1 = new Torch("Old torch");
            AddItem(torch1);
        }
    }
}
