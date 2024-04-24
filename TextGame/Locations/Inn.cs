using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Locations
{
    internal class Inn : Location
    {
        public Inn() : base("Inn")
        {
            AddDescription();
        }

        protected override void AddDescription()
        {
            Description = $"You are in {Name}";
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
