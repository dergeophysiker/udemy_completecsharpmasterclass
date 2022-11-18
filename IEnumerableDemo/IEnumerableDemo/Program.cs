using System;
using System.Collections;
using System.Collections.Generic;


namespace IEnumerableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //creating a generic IEnumerable variable that takes any collection of type int
            //we will use this variable to store the collection that will get returned by the GetCollection() method
            IEnumerable<int> unknownCollection;

            unknownCollection = GetCollction(1);

            Console.WriteLine("This was a List<int>");
            //foreach number in the collection we got back from GetCollction(1);
            foreach (int num in unknownCollection)
            {
                Console.Write(num + " ");
            }

            //new line
            Console.WriteLine("");
            //call GetCollection() with option = 2 will return a Queue<int> but we will store it
            //in the base type of generic collections.
            unknownCollection = GetCollction(2);

            Console.WriteLine("This was a Queue<int>");
            //foreach number in the collection we got back from GetCollction(2);
            foreach (int num in unknownCollection)
            {
                Console.Write(num + " ");
            }

            //new line
            Console.WriteLine("");
            //call GetCollection() with option = 5 will return a array int[] but we will store it
            //in the base type of generic collections.
            unknownCollection = GetCollction(5);
            Console.WriteLine("This was an array of int");
            //foreach number in the collection we got back from GetCollction(5);
            foreach (int num in unknownCollection)
            {
                Console.Write(num + " ");
            }
        }

        static IEnumerable<int> GetCollction(int option)
        {
            //create a list of numbers and initialize it
            List<int> numberList = new List<int>() { 1, 2, 3, 4, 5 };

             Queue<int> numbersQueue = new Queue<int>();
            //add values to the queue
            numbersQueue.Enqueue(6);
            numbersQueue.Enqueue(7);
            numbersQueue.Enqueue(8);
            numbersQueue.Enqueue(9);
            numbersQueue.Enqueue(10);
            

            /*
            Queue<string> numbersQueue = new Queue<string>();
           //add values to the queue
           numbersQueue.Enqueue("one");
           numbersQueue.Enqueue("two");
           numbersQueue.Enqueue("three");
           numbersQueue.Enqueue("four");
           */

            //if the option is 1
            if (option == 1)
            {
                //return the list of type List<int>
                return numberList;
            }
            //if the option is 2
            else if (option == 2)
            {
                //return the queue of type<int>
                return numbersQueue;
            }
            else //otherwise
            {
                //return an array of numbers initialized with some numbers
                return new int[] { 11, 12, 13, 14, 15 };
            }
        }
    }
}
