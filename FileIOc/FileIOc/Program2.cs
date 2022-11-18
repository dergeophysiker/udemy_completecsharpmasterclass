using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileIOc
{
    class Program2
    {

        static void Main(string[] args)
        {

            ArrayList myArray = new ArrayList(); 

            //Receive the Text line by line.
            string[] lines2 = System.IO.File.ReadAllLines(@"C:\Users\cxrf\OneDrive - Chevron\Documents\python\csharp\udemy_completecsharpmasterclass\FileIOc\FileIOc\input.txt");
            Console.WriteLine("Content of the file line by line:");
            foreach (string line in lines2)
            {
                //\t is a tab
               if (line.Contains("split"))
                {
                    Console.WriteLine(line);
                    String[] strlist = line.Split();
                    myArray.Add(strlist[4]);


                    foreach(string s in strlist)
                    {
                        Console.WriteLine(s);
                    }
                }

            }//foreach
            foreach(object o in myArray)
            {
                Console.WriteLine( (string) o);
            }

            using (StreamWriter file = new StreamWriter(@"C:\Users\cxrf\OneDrive - Chevron\Documents\python\csharp\udemy_completecsharpmasterclass\FileIOc\FileIOc\output.txt"))
            {
      
                foreach (object o in myArray)
                {
                    file.Write((string)o + " ");
                }


            }

        }
    }
    }
