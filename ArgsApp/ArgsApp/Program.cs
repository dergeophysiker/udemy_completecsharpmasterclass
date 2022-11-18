using System;

namespace ArgsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)   // If the user did not input 3 arguments
            {
                Console.WriteLine("ERROR: Invalid number of arguments. Please use HELP function for instructions.");
                Console.ReadKey();
                return;
            }

            if (args[0].ToLower() == "help")   // If the first argument is help. To be sure we convert it to lower case
            {
                Console.WriteLine("*****************************************************");
                Console.WriteLine("Use one of the commands below followed by two numbers");
                Console.WriteLine("add - to add two numbers");
                Console.WriteLine("sub - to sub two numbers");
                Console.WriteLine("*****************************************************");
                Console.ReadKey();
                return;
            }
           
            
            
                // If the user did input 3 arguments and first argumen is NOT help. Then do the calculation.
            
            if(args.Length !=3)

            {

                Console.Write("Invalid arguments, please use the help command for instructions.");
                Console.ReadKey();
                return;


            }

            //parse the user input if 3 things are entered

                bool isNum1Parsed = float.TryParse(args[1], out float num1);
                bool isNum2Parsed = float.TryParse(args[2], out float num2);

                if (!isNum1Parsed || !isNum2Parsed) // Check if we could convert the numbers entered by the user
                {                                   // If we dont do this check, any failed conversion will be 0
                    Console.WriteLine("ERROR: Failed to read the numbers you entered.");
                Console.ReadKey();
                    return;
                }

                float result;               // Store the result
                switch (args[0].ToLower())   // Convert the first argument to lower case and see if it is add or sub
                {
                    case "add":
                        result = num1 + num2;
                        Console.WriteLine("{0} + {1} = {2}", num1, num2, result);
                        break;
                    case "sub":
                        result = num1 - num2;
                    Console.WriteLine(num1);
                    Console.WriteLine(num2);
                    Console.WriteLine(result);

                    Console.WriteLine("{0} - {1} = {2}", num1, num2, result);
                        break;
                    default:
                        Console.WriteLine("ERROR: Invalid command");
                        break;
                }
            
        }//Main()
    }//Program
}
