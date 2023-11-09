using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphie.ShapeTypes
{
    internal class Vieleck : Shape
    {
        public Vieleck(string description, int cornerCount, ConsoleColor color)
            : base(description, cornerCount, color)
        {

        }
    }
}
