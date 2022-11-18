using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDemo
{
    class Car : Vehicle, IDestroyable
    {


        public string DestructionSound { get; set; }
        public List<IDestroyable> DestroyablesNearby;

        public Car(float speed, string color)
        {
            Speed = speed;
            Color = color;
            DestructionSound = "CarExplosionSound.mp3";
            DestroyablesNearby = new List<IDestroyable>();
        }


        public void Destroy()
        {
            Console.WriteLine("Playing destruction sound {0}", DestructionSound);
            Console.WriteLine("Create Fire");

            foreach(IDestroyable destroyable in DestroyablesNearby)
            {
                destroyable.Destroy();
            }

        }
    }
}
