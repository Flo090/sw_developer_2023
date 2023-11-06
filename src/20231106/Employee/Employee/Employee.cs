using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal class Employee
    {
        public string Name;
        public Guid Id;

        public Employee(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public Employee(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Employee");
            Console.WriteLine($"Name:\t{Name}");
            Console.WriteLine($"Id:\t{Id}");
        }
    }
}
