using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDemo
{
    class Chair : Furniture,IDestroyable
    {
        public string DestructionSound { get; set; }

        public Chair(string color, string material)
        {
            Color = color;
            Material = material;
            DestructionSound = "ChairExplosionSound.mp3";
        }

        public void Destroy()
        {
            Console.WriteLine($"The {Color} chair was destroyed.");
            Console.WriteLine("Playing destruction sound {0}", DestructionSound);
            Console.WriteLine("Spawning chair parts");



        }

    }
}
