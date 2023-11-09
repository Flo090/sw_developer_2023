using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vererbung_HAT_EIN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Radio myRadio = new Radio(105, DevicePower.Off);

            //myRadio.ShowState();

            //myRadio.ChangePowerState(DevicePower.On);
            //myRadio.Frequence = 99;
            //myRadio.ShowState();

            //myRadio.Play();

            var meinAuto = new Vehicle();

            meinAuto.SetEntertainmentPower(true);
            meinAuto.ShowInfo();
            
        }
    }
}
