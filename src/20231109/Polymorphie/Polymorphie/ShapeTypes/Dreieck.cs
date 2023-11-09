using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphie.ShapeTypes
{
    internal class Dreieck : Vieleck
    {
        public Dreieck(string description, ConsoleColor color)
            : base("Dreieck" + description, 3, color)
        {

        }
    }
}
