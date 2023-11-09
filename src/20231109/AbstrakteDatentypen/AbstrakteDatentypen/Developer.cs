using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AbstrakteDatentypen
{
    internal class Developer : Employee
    {
        private readonly decimal _baseSallery;
        private string _name;
        private Guid _id;
        private DateTime _birthdate;

        public Developer(Guid id, string name, DateTime birthday, decimal baseSallery)
        {
            _id = id;
            _name = name;
            _birthdate = birthday;
            _baseSallery = baseSallery;
        }

        public override string Name
        {
            get { return _name; }
        }
        public override Guid Id
        {
            get { return _id; }
        }
        public override int BirthYear
        {
            get { return _birthdate.Year; }
        }


        public override decimal CalculateSallery()
        {
            var age = DateTime.Now.Year - BirthYear;
            var factor = age / 5;

            return _baseSallery * (1.00m + factor / 100.0m);
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Employee");
            Console.WriteLine($"Name:\t{_name}");
            Console.WriteLine($"Id:\t{_id}");
            Console.WriteLine($"Geburtsdatum:\t{_birthdate.ToShortDateString()}");
        }
    }
}
