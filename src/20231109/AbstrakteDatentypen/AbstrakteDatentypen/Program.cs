using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrakteDatentypen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employeeList = new Employee[]
            {
                new Developer(Guid.NewGuid(),"Max Mustermann",new DateTime(2000,5,10), 1800.00m),
                new Developer(Guid.NewGuid(),"Heinz Lang",new DateTime(1980,4,20), 1800.00m)
            };

            StartCalculation(employeeList);
        }

        private static void StartCalculation(Employee[] employeeList)
        {
            foreach (var ma in employeeList)
            {
                Console.WriteLine("Infos über: " + ma.Name);

                ma.ShowInfo();
                Console.WriteLine($"Gehalt: EUR {ma.CalculateSallery():#,000.00}\n");
            }
        }
    }
}
