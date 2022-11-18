using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualOverrideDemo
{
    class Dog : Animal
    {
        public bool IsHappy { get; set; }
        public Dog(string name, int age) : base(name, age)
        {
            IsHappy = true;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Wuff!");
        }

        public override void Eat()
        {
            base.Eat();
        }

        public override void Play()
        {
            if (IsHappy)
            {
                base.Play();
            }
        }



    }
}
