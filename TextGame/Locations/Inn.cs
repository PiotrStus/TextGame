﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Locations
{
    internal class Inn : Location
    {
        public Inn() : base(LocationsNames.Inn)
        {
            AddDescription();
        }

        protected override void AddDescription()
        {
            Description = $"Your current location is: {Name}";
        }

        protected override void ChangeLocationsOptions()
        {
            throw new NotImplementedException();
        }

        protected override void AddItems()
        {
            throw new NotImplementedException();
        }
    }
}
