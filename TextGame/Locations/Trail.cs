﻿using System;
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
            Description = $"Your current location is: {Name}";
        }

        protected override void AddItems()
        {
            Item item = new Item("sword");
            //item.ItemInfo();
        }

        protected override void ChangeLocationsOptions()
        {
            throw new NotImplementedException();
        }
    }
}
