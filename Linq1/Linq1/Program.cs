using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Linq1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            OddNumbers(numbers);    



        }


        static void OddNumbers(int[] numbers)
        {
            Console.WriteLine("odd numbers: ");

            IEnumerable<int> oddNumbers = from number in numbers where number % 2 != 0 select number;
            Console.WriteLine(oddNumbers);
            
            foreach(int i in oddNumbers)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(String.Join(",",oddNumbers));
        }

    }
}
