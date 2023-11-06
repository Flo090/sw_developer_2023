using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal class Employee
    {
        private string _name;
        private DateTime _birthdate;
        private Guid _id;

        public Employee(string name, DateTime birthdate)
        {
            _name = name;
            _birthdate = birthdate;
            _id = Guid.NewGuid();
        }

        public Employee(Guid id, string name, DateTime birthdate)
        {
            _id = id;
            _name = name;
            _birthdate = birthdate;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }
        public int BirthYear
        {
            get
            {
                return _birthdate.Year;
            }
        }
        public Guid Id
        {
            get
            {
                return _id;
            }
        }
        public void ShowInfo()
        {
            Console.WriteLine("Employee");
            Console.WriteLine($"Name:\t{_name}");
            Console.WriteLine($"Id:\t{_id}");
            Console.WriteLine($"Geburtsdatum:\t{_birthdate.ToShortDateString()}");
        }
    }
}
