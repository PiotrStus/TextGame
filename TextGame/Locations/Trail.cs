using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Items;

namespace TextGame.Locations
{
    internal class Trail : Location
    {
        public Trail() : base(LocationsNames.Trail)
        {
            AddDescription();
            AddItems();
        }
        protected override void AddDescription()
        {
            Description = $"My current location is: {Name}";
        }
        protected override void AddItems()
        {
            Sword sword1 = new Sword("Blade of destiny", "silver");
            AddItem(sword1);
            Sword sword2 = new Sword("Dragon slayer", "silver");
            AddItem(sword2);
        }
    }
}
