using System;

namespace ci_exer1
{
    class Program
    {
        static void Main2(string[] args)
        {
            Console.WriteLine("Hello World!");
            string kitchen;

            kitchen = "~O~O~O~O F";
            Console.WriteLine(NotHungryCats(kitchen));

            kitchen = "O~~O~O~O F O~O~";
            Console.WriteLine(NotHungryCats(kitchen));

            kitchen = "FO~~O~O~OO~O~";
            Console.WriteLine(NotHungryCats(kitchen));

            kitchen = "F";
            Console.WriteLine(NotHungryCats(kitchen));

        }


        public static int NotHungryCats(string kitchen)
        {

            int val = 0;

            
            //remove whitespace
            string nowhitekitchen = string.Join("", kitchen.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

            Console.WriteLine(nowhitekitchen);
            // break into left and right

            char[] arr_nowhitekitchen = nowhitekitchen.ToCharArray();


            if (arr_nowhitekitchen[0].Equals('F'))
            {
                // break into rightside array
                Console.WriteLine("right array");
                string[] rightarray = nowhitekitchen.Split("F");
                string rightside = rightarray[1];

               
                
                Console.WriteLine(rightside);
                /*
                string empty = "";
                char[] test =empty.ToCharArray();

                string empty2 = "";
                char[] test2 = empty2.ToCharArray();

                string passedEmpty = "";
                char[] passTestMeArr = passedEmpty.ToCharArray();

                string testString = "";
                char[] testArr = testString.ToCharArray();

                bool result = passTestMeArr.Equals(testArr);
                Console.WriteLine(result);
                Console.WriteLine(Convert.ToChar(0x0));
                Console.WriteLine("test " + test);
                Console.WriteLine(test.Equals(Convert.ToChar(0x0)));
                Console.WriteLine(" true " + test.Equals(test2));
                Console.WriteLine("test length " + test.Length);
                Console.WriteLine("test tostring " +  test.ToString());
                Console.WriteLine("test equals empty " + test.Equals(""));
                Console.WriteLine("test equals empty " + test.Equals(' '));
                Console.WriteLine("test weualls null " + test.Equals(null));
                Console.WriteLine("test weualls \0 " + test.Equals('\0'));
                Console.WriteLine("test weualls \0 " + test.Equals( "{char[0]}" ));
                Console.WriteLine(test.Equals(default(char)));
                char[] emptyArray = new char[0];
                char[] newArray = new char[]{ 'a' };
                char[] array1 = new char[] { };
                */
               



                val = howfollow("R", rightside);

            }
            else if (arr_nowhitekitchen[arr_nowhitekitchen.Length - 1].Equals('F'))
            {
                //break into left arary
                Console.WriteLine("left array");
                string[] leftarray = nowhitekitchen.Split("F");
                string leftside = leftarray[0];
                Console.WriteLine(leftside);
                val = howfollow("L",leftside);
            }
            else
            {
                Console.WriteLine("both sides");

                string[] bothsides = nowhitekitchen.Split("F");
                string rightside = bothsides[1];
                string leftside = bothsides[0];
                
                Console.WriteLine(rightside);
                Console.WriteLine(leftside);

                int valR = howfollow ("R", rightside);
                int valL = howfollow("L", leftside);

                val = valR + valL;


            }

            int howfollow(string side,string catsToCount)
            {
                char[] sideArr = catsToCount.ToCharArray();
                int catsfollowing = 0;
                if (side.Equals("R"))
                {
                    for (int i =0; i < sideArr.Length; i=i+2)
                    {
                        if(sideArr[i]=='O' & sideArr[i+1]=='~')
                        {
                            catsfollowing++;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < sideArr.Length; i = i + 2)
                    {
                        if (sideArr[i] == '~' & sideArr[i + 1] == 'O')
                        {
                            catsfollowing++;
                        }
                    }
                }
                Console.WriteLine("done counting cats");

                return catsfollowing;
            }//method

            return val;

        }//end method
    }
}
