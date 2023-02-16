using System;
using System.Linq;

using System.Collections.Generic;

namespace Coding.Exercise
{
    public class Exercise
    {

        static void Main(string[] args)
        {
            
            /* Console.WriteLine("Hello World!");
            string kitchen;

            kitchen = "~O~O~O~O F";
            Console.WriteLine(NotHungryCats(kitchen));
            Console.WriteLine(NotHungryCats2(kitchen));

            kitchen = "O~~O~O~O F O~O~";
            Console.WriteLine(NotHungryCats(kitchen));
            Console.WriteLine(NotHungryCats2(kitchen));

            kitchen = "FO~~O~O~OO~O~";
            Console.WriteLine(NotHungryCats(kitchen));
            Console.WriteLine(NotHungryCats2(kitchen));

            kitchen = "F";
            Console.WriteLine(NotHungryCats(kitchen));
            Console.WriteLine(NotHungryCats2(kitchen));
            */

            //int[] nums = new int[] {1, 2, 3, 5, 6, 9, 11, 12, 13, 15, 20};
            int[] nums = new int[] {0, 6,6,6,6,20,20,12,14,12,18,20 };
            nums = new int[] { 0, 6, 20, 20, 12, 14, 12, 18, 20 };

            Console.WriteLine(SumOfTwo(nums, 26));
        }


        public static int NotHungryCats(string kitchen)
        {

            int val = 0;

            //remove whitespace
            string nowhitekitchen = string.Join("", kitchen.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

            // break into left and right

            char[] arr_nowhitekitchen = nowhitekitchen.ToCharArray();

            if (arr_nowhitekitchen[0].Equals('F'))
            {
                // break into rightside array
                string[] rightarray = nowhitekitchen.Split("F");
                string rightside = rightarray[1];

                val = howfollow("R", rightside);

            }
            else if (arr_nowhitekitchen[arr_nowhitekitchen.Length - 1].Equals('F'))
            {
                //break into left arary

                string[] leftarray = nowhitekitchen.Split("F");
                string leftside = leftarray[0];

                val = howfollow("L", leftside);
            }
            else
            {

                string[] bothsides = nowhitekitchen.Split("F");
                string rightside = bothsides[1];
                string leftside = bothsides[0];


                int valR = howfollow("R", rightside);
                int valL = howfollow("L", leftside);

                val = valR + valL;

            }

            int howfollow(string side, string catsToCount)
            {
                char[] sideArr = catsToCount.ToCharArray();
                int catsfollowing = 0;
                if (side.Equals("R"))
                {
                    for (int i = 0; i < sideArr.Length; i = i + 2)
                    {
                        if (sideArr[i] == 'O' & sideArr[i + 1] == '~')
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


                return catsfollowing;
            }

            return val;
        }//nothungrycats

        public static int NotHungryCats2(string kitchen)
        {

            // split the map by position of food
            var cats = kitchen.Replace(" ", "").Split('F');

            // count on both sides
            var leftCount = cats[0].Where((x, i) => i % 2 == 1).Count(x => x == '~');
            var rightCount = cats[1].Where((x, i) => i % 2 == 0).Count(x => x == '~');

            return leftCount + rightCount;
        }

        public static int SumOfTwo(int[] nums, int SumToFind)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int result = 0;

            foreach (int value in nums)

            {
                Console.WriteLine(value);

                if (dic.ContainsKey(SumToFind - value) && dic[SumToFind - value] > 0)
                {

                    dic[SumToFind - value] -= 1;

                    result++;
                    continue;
                }
                if (dic.ContainsKey(value))
                {
                    dic[value] += 1;
                }
                else
                {
                    dic.Add(value, 1);
                }
            }
            return result;
        }


    }//exercise
}//namespace
