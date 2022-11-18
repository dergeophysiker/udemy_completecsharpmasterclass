using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace FileIOc
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reading Tect from a File
            //exchange the adress of the file with the one you want to use
            string fpath = @"C:\Users\cxrf\OneDrive - Chevron\Documents\python\csharp\udemy_completecsharpmasterclass\FileIOc\FileIOc\textfile.txt";

            string text = System.IO.File.ReadAllText(@"C:\Users\cxrf\OneDrive - Chevron\Documents\python\csharp\udemy_completecsharpmasterclass\FileIOc\FileIOc\textfile.txt");

            Console.WriteLine("Textfile contains the following text: {0}", text);

            //Receive the Text line by line.
            string[] lines2 = System.IO.File.ReadAllLines(@"C:\Users\cxrf\OneDrive - Chevron\Documents\python\csharp\udemy_completecsharpmasterclass\FileIOc\FileIOc\textfile.txt");

            Console.WriteLine("Content of the file line by line:");
            foreach (string line in lines2)
            {
                //\t is a tab
                Console.WriteLine("\t" + line);
            }

            // Method 1
            string[] lines = { "First 250", "Second 242", "Third 240" };

            File.WriteAllLines(@"C:\Users\cxrf\OneDrive - Chevron\Documents\python\csharp\udemy_completecsharpmasterclass\FileIOc\FileIOc\newfile1.txt", lines);
            /*
            // Method 2
            Console.WriteLine("Please give the file a name");
            string fileName = Console.ReadLine();
            Console.WriteLine("Please enter the text for the file");
            string input = Console.ReadLine();
            File.WriteAllText(@"F:\C# Masterclass Course\Projects\Assets\" + fileName + ".txt", input);
            */
            // Method 3
            using (StreamWriter file = new StreamWriter(@"C:\Users\cxrf\OneDrive - Chevron\Documents\python\csharp\udemy_completecsharpmasterclass\FileIOc\FileIOc\newfile2.txt"))
            {
                foreach (string line in lines)
                {
                    if (line.Contains("2"))
                    {
                        file.WriteLine(line);
                    }
                }
            }

            using (StreamWriter file = new StreamWriter(@"C:\Users\cxrf\OneDrive - Chevron\Documents\python\csharp\udemy_completecsharpmasterclass\FileIOc\FileIOc\newfile2.txt", true))
            {
                file.WriteLine("Additional line");
            }

            /*
             * // Example 1 - reading Text
            string text = System.IO.File.ReadAllText(@"F:\C# Masterclass Course\Projects\Assets\textFile.txt");

            Console.WriteLine("Textfile contains following text: {0}", text);

            string[] lines = System.IO.File.ReadAllLines(@"F:\C# Masterclass Course\Projects\Assets\textFile.txt");

            Console.WriteLine("Contents of textfile.txt = ");
            foreach(string line in lines)
            {
                Console.WriteLine("\t" + line);
            }
            */
            Console.ReadKey();

            /*[Worst]

StreamWriter writer = new StreamWriter(path)

writer.WriteLines(something);



File must be closed soon after you open and read/write a file. Otherwise, various trouble occur.

For example, While your application is running, users can't edit and save the text file by other apps(Notepad). it's an nuisance. (Try it!)



[NG]

StreamWriter file= new StreamWriter(path)

writer.WriteLines(something);

file.Close(line);

//In this case. if exception occurs or you forget writing "Close()", file might not be closed.



[O.K. (but Not Recommended?)]: try-finally (∵Code is lengthy)

try

{    StreamWriter file= new StreamWriter(path);  }



finally //if exception occurs, this section is always executed.

{    file.Close();  }

*/



        }
    }
}
