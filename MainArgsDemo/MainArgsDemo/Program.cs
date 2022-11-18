using System;

namespace MainArgsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            if (args.Length == 0)
            {
                Console.WriteLine("this app uses args please try again");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Hello {0}", args[0]);


        }


    }
}
