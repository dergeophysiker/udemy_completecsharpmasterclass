using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UdemyCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //1
            int[] grades = new int[5];
            grades[0] = 1000;

            Console.WriteLine(grades.ToString());
            Console.WriteLine(grades[0]);
            //2 
            int[] gradesofstudents = { 10000, 2, 4, 6, 8 };
            Console.WriteLine(gradesofstudents[0]);
            //3
            int[] studentgrades = new int[] { 1000000, 1, 2, 3, 4 };
            Console.WriteLine(studentgrades[0]);
            

            int[] sgrades = new int[5] { 1000000, 1, 2, 3, 4 };
            Console.WriteLine(sgrades[0]);
           



            for (int i = 0; i < gradesofstudents.Length; i++)
            {
                Console.WriteLine(gradesofstudents[i]);
            }

            int j = 0;
            foreach (int k in gradesofstudents)
            {


                Console.WriteLine("{0},{1}", k, j);
                j++;
            }


            int[,] array2D = new int[,]
       {
            {1,2,3 },
            {4,5,6 },
            {7,8,9 }
       };

            foreach (int k in array2D)
            {
                Console.WriteLine(k);
            }

            string[,,] array3D = new string[,,]
             { /* 0,, */
                {
                     /* 0,0, */
                    {"000" /* 0,0,0*/, "001" /* 0,0,1 */},
                    /* 0,1, */
                    {"010", "011"},
                    /* 0,2, */
                    {"Hi there", "What's up"}
                },
                /* 1,, */
                {
                     /* 1,0, */
                    {"100", "101"},
                    /* 1,1, */
                    {"110", "111"},
                    /* 1,2, */
                    {"Another one", "Last entry"}
                }
                      };


            foreach (string k in array3D)
            {
                Console.WriteLine(k);
            }


            int dimensions = array3D.Rank;
            Console.WriteLine(dimensions);


            int[,] array2D2 = { { 1, 2 }, { 3, 4 } };
            
            Console.WriteLine("\n\n\n");

            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int l = 0; l < array2D.GetLength(1); l++)
                {
                    //Console.WriteLine(array2D[i,l]);
                    //Console.WriteLine(i + " " + l);
                    Console.WriteLine("0 based {0} in position {1} {2}", array2D[i, l],i,l);
                    Console.WriteLine("normal notation {0} in position {1} {2}", array2D[i, l], i+1, l+1);

                }
                Console.WriteLine("\n");
            }

            int count = 1;
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                //              Console.WriteLine(array2D[i, i]);
                Console.WriteLine(array2D[i, array2D.GetLength(1) - count]);
                count++;
            }
            Console.WriteLine("\n");

            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                //              Console.WriteLine(array2D[i, i]);
                Console.WriteLine(array2D[i, array2D.GetLength(1) - 1 - i]);
                count++;
            }
            Console.WriteLine("\n");



            for (int i = 0, n = 2; i < array2D.GetLength(0); i++, n--)
            {
                Console.WriteLine(array2D[i,n]);
            }


            // declare jaggedArray
            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = new int[5];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[2];

            jaggedArray[0] = new int[] { 2, 3, 5, 7, 11 };
            jaggedArray[1] = new int[] { 1, 2, 3 };
            jaggedArray[2] = new int[] { 13, 21 };
            // alternative way:
            int[][] jaggedArray2 = new int[][]
            {
                new int[] { 2, 3, 5, 7, 11 },
                new int[] { 1, 2, 3 }
            };

            foreach (Array k in jaggedArray)
            {
                Console.WriteLine(k);
                foreach(int k1 in k)
                {
                    Console.WriteLine(k1);
                }
            }
            Console.WriteLine("\n next way of doing this");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine("Element {0}",i);

                for (int j1 = 0; j1 < jaggedArray[i].Length; j1++)
                {
                    Console.WriteLine(jaggedArray[i][j1]);

                }
            }

            int[] happiness = new int[5]{ 1,2,3,4,5};

            foreach(int k2 in happiness)
            {
                Console.WriteLine("my premethod value is {0}",k2);
            }
            Console.WriteLine("\n");
           SunIsShining(happiness);

            foreach (int k2 in happiness)
            {
                Console.WriteLine("my premethod value is {0}", k2);
            }


            ParamsMethod("this", "is", "a", "long");


            
            int min = MinV2(3, 23, 23, 212122, 2, 1, -343);

            Console.WriteLine("\nminimum is {0}", min);


            //////////////////////////////////////////////////////////////////////////////
            ///// declaring an ArrayList with undefined amount of object
            ArrayList myArrayList = new ArrayList();
            // declaring an ArrayList with defined amount of object
            ArrayList myArrayList2 = new ArrayList(100);

            myArrayList.Add(25);
            myArrayList.Add("Hello");
            myArrayList.Add(13.37);
            myArrayList.Add(13);
            myArrayList.Add(128);
            myArrayList.Add(25.3);
            myArrayList.Add(13);

            // delete element with specific value from the arraylist
            myArrayList.Remove(13);
            myArrayList.Remove(13);
            myArrayList.Remove(13);
            // delete element at specific position
            myArrayList.RemoveAt(0);

            Console.WriteLine(myArrayList.Count);

            double sum = 0;

            foreach (object obj in myArrayList)
            {
                if (obj is int)
                {
                    sum += Convert.ToDouble(obj);
                }
                else if (obj is double)
                {
                    sum += (double)obj;
                }
                else if (obj is string)
                {
                    Console.WriteLine(obj);
                }
            }

            Console.WriteLine(sum);



            var numberlist = new List<int>();//list of type int without values
            var numberlist2 = new List<int> { 1, 2, 3, 4, 5 };//list of type int without values

            var numberlist3 = new List<object> { 1, "string", 3.13f, "", 3 };

            numberlist2.Add(7);
            int index = 0;
            numberlist2.RemoveAt(index);

            foreach(int element in numberlist2)
            {
                Console.WriteLine(element);
            }

            numberlist2.Clear();

            //Console.WriteLine(numberlist2[numberlist2.Count - 1]);

            foreach (object element in numberlist3)
            {
                Console.WriteLine(element);
            }



        }//end main

        //

        static void SunIsShining(int[] happiness)
        {
            for (int i = 0; i < happiness.Length; i++)
            {
                happiness[i] += 2;
            }
        }

        public static void ParamsMethod(params string[] x)
        {

            for (int i = 0; i < x.Length; i++)
            {
                Console.Write(x[i]);
            }
        }

        public static int   MinV2(params int[] numbers)
        {

            int min = int.MaxValue;

            foreach(int number in numbers)
            {
                if(number < min)
                {
                    min = number;
                }
            }

            /* or
             * 
             * int min = numbers[0]
             * for (int =1,number.Length,i++){
             * min - math.min(numbers[i],min)
             * }
             * */

            return min;
        }//end minv2





    }//end class program


    class Hashtables
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Another main function");

            Hashtable studstable = new Hashtable();


            Student stud1 = new Student(1, "jason", 98);
            Student stud2 = new Student(2, "john", 88);
            Student stud3 = new Student(3, "jo", 78);
            Student stud4 = new Student(4, "maria", 68);
            //Student stud5 = new Student(4, "maria", 68);

            studstable.Add(stud1.Id, stud1);
            studstable.Add(stud2.Id, stud2);
            studstable.Add(stud3.Id, stud3);
            studstable.Add(stud4.Id, stud4);
            //studstable.Add(stud5.Id, stud5);

            //Student storedstudent1 =  (Student) studstable[stud1.Id];


            //Console.WriteLine("{0},{1},{2}", storedstudent1.Id,storedstudent1.Name,storedstudent1.GPA);

            Console.WriteLine("{0},{1},{2}", ((Student) (studstable[stud1.Id])).Id, "hi", "there");



            foreach (DictionaryEntry entry in studstable)
            {

              Student temp = (Student)entry.Value;

               Console.WriteLine(temp.ToString());
             //   Console.WriteLine(entry.ToString()); // alternate code
            }

            Console.WriteLine("yet another way to do this \n");

            foreach(Student value in studstable.Values)
            {

                Console.WriteLine("{0}, {1}, {2}", value.Id,value.Name,value.GPA);

            }

            Hashtable table = new Hashtable();

            //our array of students
            Student[] students = new Student[4];
            students[0] = new Student(1, "Denis", 88);
            students[1] = new Student(2, "Olaf", 97);
            students[2] = new Student(6, "Ragner", 65);
            students[3] = new Student(4, "Levi", 58);

            //for each student in our students array
            foreach (Student s in students)
            {
                //first check if the student already exists, if our hashtable does not already contain our key (Student ID)
                if (!table.ContainsKey(s.Id + "Hello"))
                {
                    //if yes add the student to our hashtable and display a message
                    table.Add(s.Id + "Hello", s);
                    Console.WriteLine("Student with ID{0} was added!.", s.Id + "Hello");
                }
                else
                {
                    //if no display an error message
                    Console.WriteLine("Sorry, A student with the same ID already exists ID:{0}", s.Id);
                }

            }
            Console.WriteLine(".............................");
            foreach (Student s in table.Values)
            {

                Console.WriteLine("Student with ID{0} was added!.", s.Id);


            }


            ////////////////////////////////////////////////// dictionary code
            ///
            Employee[] employees =
{
                new Employee("CEO", "Gwyn", 95, 200),
                new Employee("Manager", "Joe", 35, 25),
                new Employee("HR", "Gwyn", 32, 21),
                new Employee("Secretary", "Petra", 28, 18),
                new Employee("Lead Developer", "Artorias", 55, 35),
                new Employee("Intern", "Ernest", 22, 8),
                new Employee("ceo", "Gwyn", 95, 200),
            };

            Dictionary<int, string> myDict = new Dictionary<int, string>()
            {
                {1, "one"},
                {2, "two"},
                {3, "three"}
            };

            Console.WriteLine(myDict[2]);

            Dictionary<string, Employee> employeesDirectory = new Dictionary<string, Employee>();

            foreach (Employee emp in employees)
            {
                employeesDirectory.Add(emp.Role, emp);
            }

            string key = "CEO";
            if (employeesDirectory.ContainsKey(key))
            {
                Console.WriteLine(employeesDirectory[key].Salary);
            }

            Console.WriteLine(employeesDirectory);
            Console.WriteLine(employeesDirectory.ToString());


            for (int i = 0; i < employeesDirectory.Count; i++)
            {
                KeyValuePair<string, Employee> keyValuePair = employeesDirectory.ElementAt(i);

                Console.WriteLine("Key: {0}", keyValuePair.Key);

                Employee employeeVal = keyValuePair.Value;

               // Console.WriteLine("Name: {0}", employeeVal.Name);
               // Console.WriteLine("Role: {0}", employeeVal.Role);
                //Console.WriteLine("Age: {0}", employeeVal.Age);
                Console.WriteLine("{0}, {1}, {2} Salary: {3}", employeeVal.Name, employeeVal.Role, employeeVal.Age, employeeVal.Salary);


            };


            Employee result = null;
          
            if (employeesDirectory.TryGetValue("Intern", out result))
            {
                Console.WriteLine("Value Retrieved.");
                Console.WriteLine("Name: {0}", result.Name);
                Console.WriteLine("Role: {0}", result.Role);
                Console.WriteLine("Age: {0}", result.Age);
                Console.WriteLine("Salary: {0}", result.Salary);

            }
            else
            {
                Console.WriteLine("The key does not exist");
            }


            foreach (var item in employeesDirectory)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }

            foreach (var item in employeesDirectory.Keys)
            {
                Console.WriteLine(item);
            }
          
            foreach (var item in employeesDirectory.Values)
            {
                Console.WriteLine(item);
            }

            string key2 = "HR";
            if (employeesDirectory.ContainsKey(key2))
            {
                Console.WriteLine("updating HR employee\n");
                Employee employeeNVal = employeesDirectory[key2];
                Console.WriteLine("{0}, {1}, {2} Salary: {3}", employeeNVal.Name, employeeNVal.Role, employeeNVal.Age, employeeNVal.Salary);

                employeesDirectory[key2] = new Employee("HR", "Eleka", 26, 18);

                employeeNVal = employeesDirectory[key2];
                Console.WriteLine("{0}, {1}, {2} Salary: {3}", employeeNVal.Name, employeeNVal.Role, employeeNVal.Age, employeeNVal.Salary);

               // Employee employeeNVal3 = employeesDirectory[key2];
                //Console.WriteLine("{0}, {1}, {2} Salary: {3}", employeeNVal3.Name, employeeNVal3.Role, employeeNVal3.Age, employeeNVal3.Salary);
            }

            Console.WriteLine(employeesDirectory);
            Console.WriteLine(employeesDirectory.ToString());


            ///////////////////////////////////////////////////////////

            StackExample StackExecute = new StackExample();

            QueueDemo QueueExecute = new QueueDemo();

        }//end main





    }//end hashtables

    class Student
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public float GPA { get; set; }

        public Student(int id, string name, float GPA)
        {
            this.Id = id;
            this.Name = name;
            this.GPA = GPA;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}",Id,Name,GPA);
            //return base.ToString();
        }

    }//Student


    public class ListsExercise
    {

        public static List<int> Solution()
        {
            // TODO: write your solution here
            //create a new list 
            List<int> myList = new List<int>();
            //go thorugh every number beyweem 100 and 170
            for (int i = 100; i <= 170; i++)
            {
                //check if its an even number
                if (i % 2 == 0)
                {
                    //add it to the list
                    myList.Add(i);
                }
            }
            //return the list
            return myList;
        }

    }//ListExercise



    public class DictionaryExercise
    {

        Dictionary<int, string> myDictionary = new Dictionary<int, string>()
        {
            {1, "one" },
            {2,"two" },
            {3,"three" }
        };

    }//DictionaryExercise

    public class Employee
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public float Rate { get; set; }
        public float Salary
        {
            get
            {
                return Rate * 8 * 5 * 4 * 12;
            }
        }
        public Employee(string role, string name, int age, float rate)
        {
            this.Role = role;
            this.Name = name;
            this.Age = age;
            this.Rate = rate;
        }

    }//CEmployee


    class StackExample
    {

        public  StackExample() {

            Console.WriteLine("####################### BEGIN STACKEXAMPLE");

            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            // use push, peek and pop

            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };

            //[5] = 7;

            foreach (var item in numbers)
            {
                Console.Write(item.ToString());
            }

            foreach (int num in numbers)
            {
                stack.Push(num);
            }

            int i = 0;
            foreach(int num in numbers)
            {
                numbers[i] = stack.Pop();
                i++;
            }
            foreach (var item in numbers)
            {
                Console.Write(item.ToString());
            }

            Console.WriteLine("####################### END STACKEXAMPLE");

        }



    }//CStackexmple

    public class QueueDemo
    {

        public QueueDemo()
        {
            Console.WriteLine("####################### BEGIN QUEUEDEMO");

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            Console.WriteLine(queue.Peek());

            Console.WriteLine("####################### END QUEUEDEMO");


        }
    }

    ///////////////////////////////
    ///

    class DebugCode
    {
        static void Main(string[] args)
        {
            // debugging tutorial
            var friends = new List<string> { "Frank", "Joe", "Michelle", "Andy", "Maria", "Carlos", "Angelina" };
            var partyFriends = GetPartyFriends(friends, 8);

            Console.WriteLine("coming to party");
            foreach (var name in partyFriends)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("all of my friends");

            foreach (var name in friends)
            {
                Console.WriteLine(name);
            }
            Console.Read();
        }
        /// <summary>
        /// this is the logic to figroue out who is a partyfriend
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<string> GetPartyFriends(List<string> list, int count)
        {
            if (list == null)
            {
                throw new ArgumentNullException();
            }
            if(count > list.Count || count <=0)
            {
                throw new ArgumentOutOfRangeException("count","Count cannot be greater than elements in the list");
            }
            
            var partyFriends = new List<string>();
            var buffer = new List<string>(list);

            while (partyFriends.Count < count)
            {
               // var currentFriend = GetPartyFriend(list);
                var currentFriend = GetPartyFriend(buffer);

                partyFriends.Add(currentFriend);
                //list.Remove(currentFriend);
                buffer.Remove(currentFriend);
            }
            return partyFriends;
        }
        public static string GetPartyFriend(List<string> list)
        {
            string shortestName = list[0];
            for (var i = 0; i < list.Count; i++)
            {
                // intentional logical bug here
                if (list[i].Length < shortestName.Length)
                {
                    shortestName = list[i];
                }
            }
            return shortestName;
        }
    }


    /////////////////////////



}//end namespace
