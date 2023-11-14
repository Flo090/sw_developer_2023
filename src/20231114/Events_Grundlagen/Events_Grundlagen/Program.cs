﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Events_Grundlagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myMusicDevice = new Radio();

            // Subscribe
            myMusicDevice.PowerStateChanged += MyMusicDevice_PowerStateChanged;

            Thread.Sleep(3000);
            myMusicDevice.ChangePowerState(DevicePower.On);
            myMusicDevice.ChangePowerState(DevicePower.On);

            // Unsubscribe
            myMusicDevice.PowerStateChanged -= MyMusicDevice_PowerStateChanged;
            myMusicDevice.ChangePowerState(DevicePower.Off);
        }

        private static void MyMusicDevice_PowerStateChanged(object sender, PowerStateChangedEventArgs e)
        {
            Console.WriteLine("Radio ist betriebsbereit...");
            Console.WriteLine($"Power Status:\n\talt: {e.OldState}\n\tnew: {e.NewState}");

            var radio = sender as Radio;
            if (radio != null)
            {
                radio.Play();
            }
        }

        //private static void MyMusicDevice_PowerStateChanged(DevicePower oldPowerState, DevicePower newPowerState)
        //{
        //    Console.WriteLine("Radio ist betriebsbereit...");
        //    Console.WriteLine($"Power Status:\n\talt: {oldPowerState}\n\tnew: {newPowerState}");
        //}
    }
}
