using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Items;

namespace TextGame.Locations
{
    internal class Inn : Location
    {
        public Inn() : base(LocationsNames.Inn)
        {
            AddDescription();
            AddItems();
        }

        protected override void AddDescription()
        {
            Description = $"Your current location is: {Name}";
        }
        protected override void AddItems()
        {
            Sword sword1 = new Sword("Faith", "silver");
            AddItem(sword1);
            Sword sword2 = new Sword("Infinity Edge", "silver");
            AddItem(sword2);
        }
    }
}
