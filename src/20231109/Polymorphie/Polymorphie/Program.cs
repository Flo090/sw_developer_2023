using Polymorphie.ShapeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shapeList = new Shape[]
            {
                new Kreis("Christina", 8,ConsoleColor.Green),
                new Dreieck("Hans",ConsoleColor.Red),
                new Shape("Max",5,ConsoleColor.White),
                new Vieleck("Maria",3, ConsoleColor.Magenta),
                new Shape("Franz",5,ConsoleColor.Yellow)
            };

            // Ausgabe der shapeList
            DisplayShapes(shapeList);
        }

        private static void DisplayShapes(Shape[] shapeList)
        {
            foreach (var shape in shapeList)
            {
                shape.Draw();
            }
        }
    }
}
