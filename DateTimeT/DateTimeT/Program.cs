using System;

namespace DateTimeT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DateTime dateTime = new DateTime(1990,01,1);
            Console.WriteLine("my birthday is {0}",dateTime);

            Console.WriteLine(DateTime.Today);
            Console.WriteLine(DateTime.Now);

            DateTime tommorrow = GetTommorrow();

            Console.WriteLine("Tommorrow will be the {0}",tommorrow);
            Console.WriteLine("Today is {0}", DateTime.Today.DayOfWeek);
            Console.WriteLine(GetFirstDayOfYear(1999));

            int days = DateTime.DaysInMonth(2000, 2);
            Console.WriteLine("Days in feb 2000: {0}",days);

            DateTime now = DateTime.Now;
            Console.WriteLine(now.Minute);

            Console.WriteLine("{0},{1},{2}", now.Hour, now.Minute, now.Second);

            Console.WriteLine("Write a date in this format: yyyy-mm-dd");
            string input = Console.ReadLine();

            if(DateTime.TryParse(input, out dateTime))
            {
                Console.WriteLine(dateTime);
                TimeSpan dayspassed = now.Subtract(dateTime);
                Console.WriteLine(dayspassed.Days);
                Console.WriteLine("Days passed since: {0}", dayspassed.Days);
            }
            else
            {
                Console.WriteLine("Wrong input");
            }


        }//Main

        static DateTime GetTommorrow()
        {
            return DateTime.Today.AddDays(1);
        }

        static DateTime GetFirstDayOfYear(int year) {

            return new DateTime(year, 1, 1);
        }

    }
}
