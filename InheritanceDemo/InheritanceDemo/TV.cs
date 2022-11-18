using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceDemo
{
    class TV : ElectricalDevice
    {

        public TV(bool isOn, string brand) : base( isOn, brand)
        {

        }//TV()


        /*
        public bool IsOn { get; set; }
        public string Brand { get; set; }
        //simple constructor
        public TV(bool isOn, string brand)
        {
            IsOn = isOn;
            Brand = brand;
        }//TV()

        public void SwitchOn()
        {
            IsOn = true;
        }//SwitchOn()
        public void SwitchOff()
        {
            IsOn = false;
        }//SwitchOff()

        */

        //method to watch TV

        public void WatchTV()
        {
            //first check if the TV is on
            if (IsOn == true)
            {
                //watch TV
                Console.WriteLine("Watching TV");
            }
            else
            {
                //print error TV
                Console.WriteLine("TV is switched off, switch it on first");
            }

        }//WatchTV()


    }//TV
}
