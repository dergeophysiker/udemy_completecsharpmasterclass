using System;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        // int age = 15;
    
        static void CoolMethod()
        {

            ///<summary>
            ///cool function
            ///</summary>

        }
        static void Main(string[] args)
        {
            
            /*
             * int age = 20;
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello Chevron");
            Console.WriteLine(age);
            string readInput = Console.ReadLine();
            Console.WriteLine("you have netered {0},{0}", readInput, readInput+"hi");
            Console.Clear();
            int readInput1 = Console.Read();
            Console.WriteLine("you have netered {0}", readInput1);
            */
            //https://www.h-schmidt.net/FloatConverter/IEEE754.html
            /*
                string stringForFloat = "0.85"; // datatype should be float
                string stringForInt = "12345"; // datatype should be int

                float newfloat = Float.Parse(stringForFloat);
                int newint = Int32.Parse(stringForInt);

                Console.Write("{0},{1}", newfloat, newint);
            */
            /*int temperature = 101;
            string answer;
            string stateofmatter;
          

       //   stateofmatter=temperature < 0 ? stateofmatter = "solid" : stateofmatter = "liquid";

            stateofmatter = temperature < 0 ? stateofmatter = "solid" :( temperature > 100 ? stateofmatter = "gas" : stateofmatter = "liquid") ;



            Console.WriteLine(stateofmatter);
            */
            for(int counter =11; counter <10;  counter++)
            {
                
                if(counter % 2==0 && counter !=0)
                {
                    Console.WriteLine("even number");
                    continue;
                }
                Console.WriteLine(counter);

            }


            Human denis = new Human();
            Human michael = new Human();

            try {
                //denis.firstName = "denis";
                denis.IntroduceMyself();




                //michael.firstName = "micheal";
                michael.IntroduceMyself();
            }

            catch (Exception e){

                Console.WriteLine(e);
            }

            finally
            {
                Human.firstName = "denis";
                denis.IntroduceMyself();


            }

            denis.LastName = "newman";
            denis.IntroduceMyself();


            Point p1 = new Point();
            p1.X = 7;

            Point p2 = p1;

            Console.WriteLine(p1.X);
            Console.WriteLine(p2.X);

            p1.X = 9;

            Console.WriteLine(p1.X);
            Console.WriteLine(p2.X);

            p2.X = 10;
            Console.WriteLine(p1.X);
            Console.WriteLine(p2.X);



            StringBuilder sb = new StringBuilder("first test");

            Foo(sb);
            Console.WriteLine(sb.ToString());
            Console.Read();

            static void Foo(StringBuilder fooSb)
            {
                fooSb.Append("test");
                Console.WriteLine(fooSb.ToString());
                fooSb = null;
                //Console.WriteLine("Am I null?" + fooSb.ToString());

            }



        }//end main
    }
}
