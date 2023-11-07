using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VererbungBeispiel
{
    internal class Kreis : Shape
    {
        public Kreis(string description, ConsoleColor color)
            : base("Kreis" + description, 0, color)
        {
            
        }
    }
}
