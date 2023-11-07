using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] myVehicleList = new Vehicle[]
            {
                new Vehicle(),
                new Vehicle("VW", ConsoleColor.Green, 100, 200),
                new Vehicle("Schoolbus", ConsoleColor.Yellow,95,130),
                new Bike("Moto Cross", 10, 100, ConsoleColor.Red, 220),
                new Bike()
        };

            foreach (var vehicle in myVehicleList)
            {
                // Fahrzeug Farbe setzen
                Console.ForegroundColor = vehicle.Color;

                // Fahrzeug beschleunigen
                vehicle.SpeedUp(vehicle.MaxSpeed - 2);

                // Ausgabe
                vehicle.ShowInfo();
                Console.WriteLine();
            }
            Console.ResetColor();

            //Bike bike = new Bike();
            //Bike cross = new Bike("Moto Cross", 10, 100, ConsoleColor.Red, 220);
            //bike.ShowInfo();
            //cross.ShowInfo();
        }
    }
}
