using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    internal class Bike : Vehicle
    {
		private int _suspensionTravel;

        public Bike() : base("Vespa Std.", ConsoleColor.Red, 5, 42)
        {
            _suspensionTravel = 180;
        }

        public Bike(string bikeDescription, int ps, int maxSpeed, ConsoleColor bikeColor, int suspensionTravel) 
            : base(bikeDescription, bikeColor, ps, maxSpeed)
        {
            _suspensionTravel = suspensionTravel;
        }

        public int SuspensionTravel
		{
			get { return _suspensionTravel; }
		}

	}
}
