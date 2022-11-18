using System;

namespace StructsC2
{
    enum Day { Mo, Tu, We, Th, Fr, Sa, Su };
    enum Month { Jan = 1, Feb, Mar, Apr, May, Jun, Jul = 12, Aug, Sep, Oct, Nov, Dec };
    enum ArrivalStatus { Late = -1, OnTime = 0, Early = 1 };

    struct Game
    {
        public string name;
        public string developer;
        public double rating;
        public string releaseDate;
        public string gamenumber;

        /* public Game(string name, string developer, double rating, string releaseDate)
         {
             this.name = name;
             this.developer = developer;
             this.rating = rating;
             this.releaseDate = releaseDate;
         } */

        public void Display()
        {
            Console.WriteLine("Game {1}'s name is :{0}", name, gamenumber);
            Console.WriteLine("Game {1}'s was developed by :{0}", developer, gamenumber);
            Console.WriteLine("Game {1}'s rating is :{0}", rating, gamenumber);
            Console.WriteLine("Game {1} was released in :{0}\n", releaseDate, gamenumber);
        }

    }



    class Program
    {
        static void Main(string[] args)
        {

            Game game1;
            Game game2;
            string name = "";

            game1.name = "Pokemon Go";
            game1.developer = "Niantic";
            game1.rating = 3.5;
            game1.releaseDate = "01.07.2016";
            game1.gamenumber = "1";

            // game1.Display();
            game1.Display();

            game2 = game1;
            game2.name = "Fallout";
            game2.gamenumber = "2";

            game2.Display();
            game1.Display();


            Day fr = Day.Fr;
            Day su = Day.Su;

            Day a = Day.Fr;
            //name = (string)ArrivalStatus.Early;
            name = Enum.GetName(typeof(ArrivalStatus), ArrivalStatus.Early);
            Console.WriteLine(fr == a);
            Console.WriteLine((ArrivalStatus.Early));
            Console.WriteLine(name);
            Console.WriteLine(Day.Mo);
            Console.WriteLine((int)Day.Mo);

            Console.WriteLine((int)Month.Feb);
            Console.WriteLine((int)Month.Aug);

            foreach (Month month in Enum.GetValues(typeof(Month)))
            {
                Console.WriteLine((int)month);
            }

        }
    }
}
