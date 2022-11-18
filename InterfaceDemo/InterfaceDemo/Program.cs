using System;
using System.Collections;
using System.Collections.Generic;

namespace InterfaceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var objlist = new List<object> { };



            Chair officeChair = new Chair("brown", "plastic");
            Chair gamingChair = new Chair("red", "wood");
            Car damangedCar = new Car(80f, "blue");
            Tank bigTank = new Tank(40f, "green");

            objlist.Add(officeChair);
            objlist.Add(gamingChair);
            objlist.Add(bigTank);

            foreach(var someobj in objlist)
            {
                if (someobj is IDestroyable)
                {
                    damangedCar.DestroyablesNearby.Add((IDestroyable)someobj);
                }
     
            }

            damangedCar.Destroy();

        }
    }
}
