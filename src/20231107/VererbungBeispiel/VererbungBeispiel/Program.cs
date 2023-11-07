using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VererbungBeispiel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape[] myShapesList = new Shape[]
            {
                new Shape("Figur",5,ConsoleColor.Red),
                new Kreis("Figur2",ConsoleColor.White),
                new Dreieck("Figur3",ConsoleColor.Blue),
                new Vieleck("Vieleck",5, ConsoleColor.Yellow)
            };

            DisplayShapes(myShapesList);
        }

        private static void DisplayShapes(Shape[] myShapesList)
        {
            foreach (Shape shape in myShapesList)
            {
                shape.Draw();
                Console.WriteLine();
            }
        }
    }
}
