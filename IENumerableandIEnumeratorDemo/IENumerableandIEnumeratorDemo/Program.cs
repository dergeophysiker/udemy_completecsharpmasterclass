using System;
using System.Collections;
using System.Collections.Generic;

namespace IENumerableandIEnumeratorDemo
{
    class Program

    //1. IEnumerable <T> for non generic collction
    //2. IEnumerable for generic collection
    {

        /// <summary>
        /// IEnumerable<T> contains a single method that you must implement this interface;
        /// GetEnumerator(), which returns an IEnumerator<T> object.
        /// The returned IEnumrator<T> provides the ability to iterate through the collection 
        /// by exposing a Current property that points at the object we are currently at in the collection.
        /// 
        /// When it is recommended to use the IEnumerable Interface:
        /// - Your collection represents a massive database table,
        /// you don't want co copy the entire thing into memory and cause performance issues in your application
        /// When it is recommended to use the IEnumerable Interface:
        /// you need the results right away and are possibly mutating / editing the objects later on.
        /// In this case, it is better to use an Array or a List
        /// 
        ///  because let's say a friend of mine works on the Shelter Class and I work on the Dog Class. since we are from different continents its hard to communicate.
        ///  But what I will always be aware of is that I can do foreach(Dog dog in shelter) and always enumerate through the dog list. He also knows that I
        /// can do that. As long as he implements the IEnumerable Interface he can do whatever he wants in the Shelter class and I wont have to care. if he 
        /// decides to change his method of storing dogs, he can do so without keeping the same name. if he wants to make the dogs list private, he can do 
        /// so. He can do whatever he wants in there as long as IEnumerator is implemented and adapted correct. No matter how much he changes his code I will
        /// not have to worry about changing mine because mine will always work since we both know that I USE THE IENUMERABLE CLASS. Hope this helps a bit

        /// 
        /// </summary>

        static void Main(string[] args)
        {
            DogShelter shelter = new DogShelter();

            foreach (Dog dog in shelter)
            {
                if (!dog.IsNaughtyDog)
                {
                    dog.GiveTreat(2);
                }
                else
                {
                    dog.GiveTreat(1);
                }
            }
        }
    }

    class Dog
    {
        //the name of the dog
        public string Name { get; set; }

        //is this a naughty dog?
        public bool IsNaughtyDog { get; set; }

        //simple constructor
        public Dog(string name, bool isNaughtyDog)
        {
            this.Name = name;
            this.IsNaughtyDog = isNaughtyDog;

        }

        //This method will print how many treats the dog received
        public void GiveTreat(int numberOfTreats)
        {
            //print a message containing the number of treats and the name of the dog
            Console.WriteLine("Dog: {0} said wuoff {1} times!", Name, numberOfTreats);
        }
    }
    //a class named DogShelter this class contains a generic collction of type Dog
    //objects of this class can't be used inside a for each loop because it lacks an implementation of the IEnumerable interface
    class DogShelter : IEnumerable<Dog>
    {
        //list of type List<Dog>
        public List<Dog> dogs;

        //this constrictor will initialize the dogs list with some values
        public DogShelter()
        {
            //initialize the dogs list using the collection initializer
            dogs = new List<Dog>()
            {
                new Dog("Casper", false),
                new Dog("Sif", true),
                new Dog("Oreo", false),
                new Dog("Pixel", false)

            };
        }

        IEnumerator<Dog> IEnumerable<Dog>.GetEnumerator()
        {
            return dogs.GetEnumerator(); // returns an IEnumerator<Dog>
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    
        }
}
