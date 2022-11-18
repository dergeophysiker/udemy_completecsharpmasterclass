using System;

namespace VirtualOverrideDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Dog dog = new Dog("sif", 50);
            dog.MakeSound();
            dog.Play();
            dog.Eat();


        }
    
    }
}
