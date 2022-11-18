using System;

namespace InheritanceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Radio myRadio = new Radio(false, "Sony");
            myRadio.SwitchOn();
            myRadio.ListenRadio();
            myRadio.SwitchOff();

            TV myTV = new TV(false, "Samsung");
            myTV.SwitchOn();
            myTV.WatchTV();

        }
    }
}
