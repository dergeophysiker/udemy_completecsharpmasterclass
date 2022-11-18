using System;
using System.Collections.Generic;

namespace DelegatesDemo
{
    class Program
    {

        public delegate bool FilterDelegate(Person p1);


        /*For the most part, you can think of a delegate as "an interface with a single method"
         * for which you can provide the implementation inline without having to define a class, a method and an object instance
         * (the compiler will generate these things for you). And you already know the purpose of interfaces: 
         * they are used to enable a polymorphic behaviour (eg. strategy pattern).
         */ 
  
        static void Main(string[] args)
        {

            /* code for previous lesson Section 153
             * 
            Console.WriteLine("Hello World!");

            List<string> names = new List<string>() { "Aiden", "Sif", "Walter", "Anatoli" };
            Console.WriteLine("---before");
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }

            names.RemoveAll(Filter);
            Console.WriteLine("---after");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    
        static bool Filter(string s)
        {
            return s.Contains("i");
        }
            */

        Person p1 = new Person() { Name = "Aiden", Age = 41 };
            Person p2 = new Person() { Name = "Sif", Age = 69 };
            Person p3 = new Person() { Name = "Walter", Age = 12 };
            Person p4 = new Person() { Name = "Anatoli", Age = 25 };

            List<Person> people = new List<Person>() { p1, p2, p3, p4 };

            DisplayPeople("kids", people, IsMinor);
            DisplayPeople("adults", people, IsAdult);
            DisplayPeople("Senior", people, IsSenior);


            //anontmous method as a parameter then passed
            FilterDelegate filter1 = delegate (Person p9)
            {
                return p9.Age >= 20 && p9.Age <= 30;
            };

            DisplayPeople("between 20 and 30", people, filter1);
            
            
            //anonymous method passed as a parameter
            DisplayPeople("All: ", people, delegate (Person p10)
            {
                return true;
            });

            //lambda expression
            string searchKeyword = "A";
            DisplayPeople("Age > 20 with search keyword:" + searchKeyword, people, (p5) => { 
            
                if(p5.Name.Contains(searchKeyword) && p5.Age > 20)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            
            });

            //lambda statement
            DisplayPeople("exactly 25:", people, p6 => p6.Age == 25);


        }//Main()


        static void DisplayPeople(string title, List<Person> people, FilterDelegate filter)
        {
            Console.WriteLine(title);

            foreach (Person p2 in people)
            {
                if (filter(p2))
                {
                    Console.WriteLine("{0}, {1} years old", p2.Name,p2.Age);
                }
            }

        }//DisplayPeople()

        //===============Filters=================
        static bool IsMinor(Person p)
        {
            return p.Age < 18;
        }

        static bool IsAdult(Person p)
        {
            return p.Age >= 18;
        }

        static bool IsSenior(Person p)
        {
            return p.Age >= 65;
        }


     }//Program

        class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }//Person

}
