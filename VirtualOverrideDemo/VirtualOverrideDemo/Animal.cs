using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualOverrideDemo
{
    class Animal
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsHungry { get; set; }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
            IsHungry = true;

        }

        //add empty method that can be overridden
        public virtual void MakeSound()
        {

        }

        public virtual void Eat()
        {
            if (IsHungry)
            {
                Console.WriteLine($"{Name} Eating");
            }
            else
            {
                Console.WriteLine($"{Name} is not hungry");
            }
        }

        public virtual void Play()
        {
            Console.WriteLine($"{Name} is playing");

        }

    }
}
