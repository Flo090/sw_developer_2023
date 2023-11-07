using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VererbungBeispiel
{
    internal class Shape
    {
        private string _description;
        private int _cornerCount;
        private ConsoleColor _color;

        public Shape(string description, int cornerCount, ConsoleColor color)
        {
            _description = description;
            _cornerCount = cornerCount;
            _color = color;
        }

        public string Description
        {
            get { return _description; }
        }
        public int CornerCount
        {
            get { return _cornerCount; }
        }
        public ConsoleColor Color
        {
            get { return _color; }
            set { _color = value; }
        }


        public void Draw()
        {
            Console.ForegroundColor = _color;
            Console.WriteLine($"Description: {_description}");
            Console.WriteLine($"Corner Count: {_cornerCount}");
            Console.WriteLine($"Color: {_color}");

            Console.ResetColor();
        }
    }
}
