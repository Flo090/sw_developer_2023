using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee myEmployee = new Employee("Max Mustermann", new DateTime(1980,5,20));

            myEmployee.ShowInfo();

            Console.WriteLine($"Geburtsjahr: {myEmployee.BirthYear}");
        }
    }
}
