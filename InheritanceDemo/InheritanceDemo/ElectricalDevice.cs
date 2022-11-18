using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceDemo
{
    class ElectricalDevice
    {
        public bool IsOn { get; set; }
        public string Brand { get; set; }
        //simple constructor
        public ElectricalDevice(bool isOn, string brand)
        {
            IsOn = isOn;
            Brand = brand;
        }

        public void SwitchOn()
        {
            IsOn = true;
        }
        public void SwitchOff()
        {
            IsOn = false;
        }

        //method to listen to the radio
    }
}
