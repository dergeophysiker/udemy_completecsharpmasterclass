using System;

namespace NullablesE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int? num1;

            double? num6 = 13.1;
            double? num7 = null;
            double num8;
            int? int10 = 5;

            Console.WriteLine(Math.Pow(int10,int10));

            if(num6 == null)
            {
                num8 = 0.0;

            }
            else
            {
                num8 = (double)num6;
            }

            num8 = num7 ?? 8.53;

        }
    }
}
