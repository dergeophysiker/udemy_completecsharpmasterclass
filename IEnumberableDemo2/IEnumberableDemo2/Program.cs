using System;

namespace IEnumberableDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            // a list of type List<int> initialized with some numbers
            List<int> numberList = new List<int>() { 8, 6, 2 };

            // an array of type<int> initialized with some numbers
            int[] numberArray = new int[] { 1, 7, 1, 3 };

            //new line
            Console.WriteLine(" ");

            //call CollectionSum() and pass the list to it
            CollectionSum(numberList);

            Console.WriteLine(" ");

            //call CollectionSum() and pass the array to it
            CollectionSum(numberArray);
        }

        static void CollectionSum(IEnumerable<int> anyCollection)
        {
            //sum variable to sore the sum of the numbers in anyColletion
            int sum = 0;

            //for each number in the collection passed to this method
            foreach (int num in anyCollection)
            {
                //add the num value to the sum 
                sum += num;
            }

            //print the sum
            Console.Write("Sum is {0}", sum);
        }
    }
}
