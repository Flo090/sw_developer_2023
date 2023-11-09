using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vererbung_HAT_EIN
{
    internal class Vehicle
    {
        private string _description;
        private ConsoleColor _color;
        private int _ps;
        private int _currentSpeed;
        private int _maxSpeed;

        private Radio _vehicleRadio;

        public Vehicle()
        {
            _description = "Family Car";
            _color = ConsoleColor.Blue;
            _ps = 140;
            _maxSpeed = 187;
            _currentSpeed = 0;
            _vehicleRadio = new Radio();
        }
        public Vehicle(string description, ConsoleColor color, int ps, int maxSpeed)
        {
            _description = description;
            _color = color;
            _ps = ps;
            _currentSpeed = 0;
            _maxSpeed = maxSpeed;
            _vehicleRadio = new Radio();
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }
        public ConsoleColor Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        public int Ps
        {
            get
            {
                return _ps;
            }
        }
        public int CurrentSpeed
        {
            get
            {
                return _currentSpeed;
            }
        }
        public int MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
        }

        public void SetEntertainmentPower(bool isOn)
        {
            if (isOn)
            {
                _vehicleRadio.ChangePowerState(DevicePower.On);
            }
            else
            {
                _vehicleRadio.ChangePowerState(DevicePower.Off);
            }
        }

        public void MakeSound()
        {
            _vehicleRadio.Play();
        }
        public void SpeedUp(int delta)
        {
            if (_currentSpeed + delta < 0)
            {
                _currentSpeed = 0;
            }
            else if (_currentSpeed + delta > _maxSpeed)
            {
                _currentSpeed += delta;
            }
            else
            {
                _currentSpeed += delta;
            }
        }
        public void ShowInfo()
        {
            Console.WriteLine("Vehicle");
            Console.WriteLine($"Description:\t{_description.ToUpper()}");
            Console.WriteLine($"Color:\t\t{_color}");
            Console.WriteLine($"PS:\t\t{_ps} Ps");
            Console.WriteLine($"Current Speed:\t{_currentSpeed} km/h");
            Console.WriteLine($"Maximum Speed:\t{_maxSpeed} km/h");
            _vehicleRadio.ShowState();
        }
    }
}
