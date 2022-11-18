using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceDemo
{
    class Radio : ElectricalDevice
    {

        public Radio(bool isOn, string brand) : base(isOn,brand) // pass parameters to baseclass during instatation
        {

        }

        /* /// inherting from baseclass so dont need it
         * 
        public bool IsOn { get; set; }
        public string Brand { get; set; }
        //simple constructor
        
        
        public Radio(bool isOn, string brand)
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
        */


        public void ListenRadio()
        {
            //first check if the radio is on
            if (IsOn == true)
            {
                //listen to the radio
                Console.WriteLine("Listening to the Radio!");
            }
            else
            {
                //print error message
                Console.WriteLine("Radio is switched off, switch it on first");
            }

        }
    }//Radio

}
