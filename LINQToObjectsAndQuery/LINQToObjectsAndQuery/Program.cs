using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


/*
 * 
 * Some might prefer Lambda Expressions instead of query Syntax..
(In this Chapter, First Method in Lambda Expressions comes up suddenly)
I wrote down  the examples  of the  Lambda Expressions . For your information.

Lecture 191
var oddNumbers2 = numbers.Where(n => n % 2 == 1);

Lecture 192
var maleStudents2 = students.Where(x => x.Gender == "Male");

Lecture193
var sortedStudent2 = students.OrderBy(x => x.Age);
var reversedSortedInts = someints.OrderByDescending(x => x);

Lecture 194
var newCollection2 = students.Join(universities, x => x.UniversityId, y => y.Id,
                    (x, y) => new { Name = x.Name, UniversityName = y.Name })
                     .OrderBy(x => x.Name);
// another one
foreach (Student student in students.Where(s => s.Gender =="Male"))
{
    Console.WriteLine($"Student {student.Name} with I         D {student.ID}, age {student.Age} at University ID {student.UniversityID}");
}

*/









namespace LINQToObjectsAndQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            UniversityManager um = new UniversityManager();
            um.MaleStudents();
            um.femaleStudents();
            um.SortStudentsByAge();
            um.AllStudentsFromSchool("Beijing Tech");
            um.AllStudentsFromSchool(1);
            um.AllStudentsFromSchool(2);
            um.AllStudentsFromSchool(3);

            int[] someInts = { 30, 23, 4, 111, 33, 0, -32 };
            IEnumerable<int> sortedInts = from i in someInts orderby i select i;
            IEnumerable<int> reversedInts = sortedInts.Reverse();

            foreach(int i in reversedInts)
            {
                Console.WriteLine(i);
            }

            IEnumerable<int> reversedIntsDesc = from i in someInts orderby i ascending select i;

            foreach (int i in reversedIntsDesc)
            {
                Console.WriteLine(i);
            }


            um.StudentAndUniversityCollection();



        }



    }

    class University
    {
        public int  Id { get; set; }
        public string Name { get; set; }
    
        public void Print()
        {
            Console.WriteLine("university {0} with id {1}", Name,Id);
        }
    
    }//class

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender  { get; set; }
        public int Age { get; set; }

        public int UniversityId { get; set; }

        public void Print()
        {
            Console.WriteLine("student {0} with id {1}, gender {2}, age {3} from university with id {4}", Name,Id,Gender,Age,UniversityId);
        }


    }//class

    class UniversityManager
    {
        public List<University> universities;
        public List<Student> students;
        public List<Student> mstudents;

        public UniversityManager()
        {
            universities = new List<University>();
            students = new List<Student>();
            mstudents = new List<Student>();

            //add universities
            universities.Add(new University { Id = 1, Name = "Yale" });
            universities.Add(new University { Id = 2, Name = "Beijing Tech" });
            //Adding Students
            students.Add(new Student { Id = 1, Name = "Carla", Gender = "female", Age = 47, UniversityId = 1 });
            students.Add(new Student { Id = 2, Name = "Frank", Gender = "male", Age = 31, UniversityId = 4 });
            students.Add(new Student { Id = 32, Name = "Toni", Gender = "male", Age = 21, UniversityId = 1 });
            students.Add(new Student { Id = 3, Name = "Leyla", Gender = "female", Age = 19, UniversityId = 2 });
            students.Add(new Student { Id = 4, Name = "James", Gender = "trans-gender", Age = 25, UniversityId = 2 });
            students.Add(new Student { Id = 5, Name = "Linda", Gender = "female", Age = 72, UniversityId = 2 });

        }//constructor

        public void MaleStudents()
        {
            /* var thing = from student in students where student.Gender == "male" select student;
            Console.WriteLine(thing.GetType()); */
IEnumerable<Student> maleStudents = from student in students where student.Gender == "male" select student;
            Console.WriteLine("Male students: ");
            
            foreach(Student student in maleStudents)
            {
                student.Print();
            }

/*
            foreach(var mstudent in thing)
            {
                mstudent.Print();
            }
*/
        }//method

        public void femaleStudents()
        {

            IEnumerable<Student> femaleStudents = from student in students where student.Gender == "female" select student;
            Console.WriteLine("Female students: ");

            foreach (Student student in femaleStudents)
            {
                student.Print();
            }

        }//method


        public void SortStudentsByAge()
        {
            var sortedStudents = from student in students orderby student.Age select student;
            Console.WriteLine("students sorted by age:");
            foreach (var student in sortedStudents)
            {
                student.Print();
            }
        }//method

        public void AllStudentsFromSchool(string uni)
        {
            IEnumerable<Student> studentsU = from student in students join university in universities on student.UniversityId equals university.Id where university.Name == uni select student;

            Console.WriteLine("students from {0}:",uni);

            foreach (var student in studentsU)
            {
                student.Print();
            }

                }//method

        public void AllStudentsFromSchool(int uni)
        {
            IEnumerable<Student> studentsU = from student in students join university in universities on student.UniversityId equals university.Id where university.Id == uni select student;

            var uniName = from univ in universities where univ.Id == uni select univ.Name;
            /*
            Console.WriteLine(uniName.First());

            Debug.WriteLine(uniName);
            Debug.WriteLine(uniName.GetType());
            */
            Console.WriteLine("students from {0}:", uniName.FirstOrDefault());
            

            Console.WriteLine("students from {0}:", uni);
            foreach (var student in studentsU)
            {
                student.Print();
            }

            Debug.Write(studentsU);
            Debug.Write(uniName);



        }//method

        public void StudentAndUniversityCollection()
        {
            var newCollection = from student in students join university in universities on student.UniversityId equals university.Id orderby student.Name select new { StudentName = student.Name, UniversityName=university.Name };
            var newC = from student in students join university in universities on student.UniversityId equals university.Id orderby student.Name select (university, student);

            IEnumerable<OutputModel> outputs = from student in students join university in universities on student.UniversityId equals university.Id orderby student.Name select new OutputModel{ UniversityName = university.Name, Student = student };


            foreach (var item in newC)
            {
                Console.WriteLine(item);
                Console.WriteLine(item.ToString());
                Console.WriteLine(item.student.Name);
                item.university.Print();
                item.student.Print();

            }



            Console.WriteLine("New Collection: ");
            foreach (var col in newCollection)
            {
                Console.WriteLine(col.GetType());
                Console.WriteLine("Student {0} from University {1}", col.StudentName, col.UniversityName);
            }


            foreach (OutputModel someout in outputs)
                {
                someout.showDetails();
            }


        }//method




    }//class

    class OutputModel
    {
        public string UniversityName { get; set; }
        public Student Student { get; set; }

        public void showDetails()
        {
            Console.WriteLine(Student.Name + " " + Student.Id + " " + Student.Gender + " " + Student.Age  + " " + UniversityName );
        }
    }


}
