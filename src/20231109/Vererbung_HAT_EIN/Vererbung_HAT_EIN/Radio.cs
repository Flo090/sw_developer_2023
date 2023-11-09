using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vererbung_HAT_EIN
{
    internal class Radio
    {
        private int _frequence;
        private DevicePower _powerState;

        public Radio()
        {
            _frequence = 90;
            _powerState = DevicePower.Off;
        }
        public Radio(int frequence, DevicePower powerState)
        {
            _frequence = frequence;
            _powerState = powerState;
        }

        public int Frequence
        {
            get { return _frequence; }
            set
            {
                if (value >= 87.6 && value <= 107.9)
                {
                    _frequence = value;
                }
            }
        }
        public DevicePower PowerState
        {
            get { return _powerState; }
        }

        public void ShowState()
        {
            Console.WriteLine("Radio:");
            Console.WriteLine($"Power State: {_powerState}");
            Console.WriteLine($"Frequence: {_frequence} MHz");
            Console.WriteLine();
        }
        public void Play()
        {
            if (_powerState == DevicePower.On)
            {
                Console.WriteLine($"Play at Frequence {_frequence} MHz");
            }
        }
        public void ChangePowerState(DevicePower newPowerState)
        {
            switch (newPowerState)
            { 
                case DevicePower.Off:
                case DevicePower.Standby:
                case DevicePower.On:
                    _powerState = newPowerState;
                break;

                case DevicePower.Unknown:
                case DevicePower.Defective:
                    // Status kann nicht von ext. gesetzt werden
                    break;

                default:
                    throw new ArgumentException("Ungültiger DeviceState entdeckt !!!");
            }
        }
    }
}
