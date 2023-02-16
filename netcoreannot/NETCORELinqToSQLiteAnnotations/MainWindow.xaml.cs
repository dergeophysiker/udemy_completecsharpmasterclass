using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using NETCORELinqToSQLiteAnnotations.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace NETCORELinqToSQLiteAnnotations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        NETCORELinqToSQLiteAnnotations.Models.DemoDBContext dataDBContext;
        public MainWindow()
        {
            InitializeComponent();

            dataDBContext = new NETCORELinqToSQLiteAnnotations.Models.DemoDBContext();

            Debug.WriteLine("something");


            InsertUniversities();
            Debug.WriteLine("done inserting");
            InsertStudent();
            
            /*
            InsertLectures();
            InsertStudentLectureAssociations();
            GetUniversityofTony();
            GetLecturesofTony();
            GetAllStudentsFromYale();
            GetAllUniversitiesWithTransgender();
            GetAllLecturesFromBeijingTech();
            UpdateStudent("Tony", "Anthony");
            */
            GetAllStudentsWithUniversities();
            GetAllStudents();

            DeleteStudent("James");


           

            using (var context = new NETCORELinqToSQLiteAnnotations.Models.DemoDBContext())
            {
                var artistppl = from a in context.Universities
                                //where a.Name.StartsWith("E")
                                orderby a.Name
                                select a;

                foreach (var temp in artistppl)
                {
                    Debug.WriteLine(temp.Name);
                }

                Debug.WriteLine(context.Lectures.Count());
                
              ///*
                var myEntity = new University { Id=2, Name = "SchoolName" };
               // context.Universities.Update(myEntity);
                context.Universities.Add(myEntity);

                context.SaveChanges();

                University uga = new University();
                uga.Name = "University of Georgia";
              //  context.Universities.Add(uga);
                context.Universities.Update(uga);
                context.SaveChanges();
                *///
        } 
         



        }//end mainwindows


        public void InsertUniversities()
        {
            University yale = new University();
            yale.Name = "Yale";
            dataDBContext.Universities.Add(yale);
       
            University beijingTech = new University();
            beijingTech.Name = "Beijing Tech";
            dataDBContext.Universities.Add(beijingTech);
            
            dataDBContext.SaveChanges();

            // ddlCon.DataSource = (from em in dw.Employees      select new { em.Title, em.EmployeeID }).ToList();

        

            //MainDataGrid.ItemsSource = dataDBContext.Universities.ToList();

            var obscol = dataDBContext.Universities.Local.ToObservableCollection();

            MainDataGrid.ItemsSource = obscol;



            University dummy = new University();
            dummy.Name = "MainDataGrid";

            obscol.Add(dummy);

            var txtcolumn = new DataGridTextColumn();
            txtcolumn.Header = "MainDataGrid";

            MainDataGrid.Columns.Insert(0,txtcolumn);





        }//end

        public void InsertStudent()
        {
            University yale = dataDBContext.Universities.First(un => un.Name.Equals("Yale"));
            //from university in dataDBcontext.University where university == "Yale" select university
            University beijingTech = dataDBContext.Universities.First(un => un.Name.Equals("Beijing Tech"));

            List<Student> students = new List<Student>();

            students.Add(new Student { Name = "Carla", Gender = "female", UniversityId = yale.Id } );
            students.Add(new Student { Name = "Tony", Gender = "male", University = yale } );
            students.Add(new Student { Name = "James", Gender = "undisclosed", University = beijingTech } );
            //students.Add(new Student { Name = "Layla1", Gender = "female", University = beijingTech } );

            dataDBContext.Students.AddRange(students);
            

         dataDBContext.SaveChanges();

           // MainDataGrid2.ItemsSource = dataDBContext.Students.ToList();
            MainDataGrid2.ItemsSource = dataDBContext.Students.Local.ToObservableCollection();

            // MainDataGrid2.ItemsSource = dataDBContext.Students.ToHashSet();
            // MainDataGrid2.ItemsSource = dataDBContext.Students;
            //MainDataGrid2.ItemsSource = dataDBContext.Students.Local.ToObservableCollection();

            //MainDataGrid2.ItemsSource = dataDBContext.Students.Include(t => t.University.Name).ToList(); ;

            //MainDataGrid2.ItemsSource = dataDBContext.Students.Include(student => student.University).ThenInclude(University => University.Name);
            //var something = dataDBContext.Students.Include(student => student.University).ThenInclude(university => university.Name);
            //var something2 = something.ToList();

            //MainDataGrid2.ItemsSource = something.ToList();


            foreach (var stud in dataDBContext.Students.Include(stud => stud.University))
            {
                Debug.WriteLine($"{stud.Name} at {stud.University.Name}");
            }


            //MainDataGrid2.ItemsSource = dataDBContext.Students.Local.ToObservableCollection

            var txtcolumn2 = new DataGridTextColumn();
            txtcolumn2.Header = "MainDataGrid2";

            MainDataGrid2.Columns.Insert(0, txtcolumn2);

            Debug.WriteLine("done");

        }//end method


        /// <summary>
        /// ///////////////////////////////////////////////
        /// </summary>
        /// 

        public void InsertLectures()
        {

            List<Lecture> lectures = new List<Lecture>
            {
                new Lecture { Name = "Analysis" },
                new Lecture { Name = "Organic Chemistry" }
            };

            dataDBContext.AddRange(lectures);
            dataDBContext.SaveChanges();
            
           
            MainDataGrid4.ItemsSource = dataDBContext.Lectures.ToList();
            MainDataGrid3.ItemsSource = dataDBContext.Lectures.Local.ToObservableCollection();

            var txtcolumn3 = new DataGridTextColumn();
            txtcolumn3.Header = "MainDataGrid3";

            MainDataGrid3.Columns.Insert(0, txtcolumn3);

            var txtcolumn4 = new DataGridTextColumn();
            txtcolumn4.Header = "MainDataGrid4";

            MainDataGrid4.Columns.Insert(0, txtcolumn4);




        }//end method

        public void InsertStudentLectureAssociations()
        {

            Student Carla = dataDBContext.Students.First( st => st.Name.Equals("Carla"));
            Student Tony = dataDBContext.Students.First(st => st.Name.Equals("Tony"));
            Student James = dataDBContext.Students.First(st => st.Name.Equals("James"));

            Lecture Analysis = dataDBContext.Lectures.First(lc => lc.Name.Equals("Analysis"));
            Lecture Ochem = dataDBContext.Lectures.First(lc => lc.Name.Equals("Organic Chemistry"));

            dataDBContext.StudentLectures.Add(new StudentLecture { Student = Carla, Lecture = Analysis });
            dataDBContext.StudentLectures.Add(new StudentLecture { Student = Tony, Lecture = Ochem });
            dataDBContext.StudentLectures.Add(new StudentLecture { Student = Tony, Lecture = Analysis });


            StudentLecture sljames = new StudentLecture();

            sljames.Student = James;
            sljames.LectureId = Ochem.Id;
            dataDBContext.StudentLectures.Add(sljames);
            dataDBContext.SaveChanges();
            //MainDataGrid5.ItemsSource = dataDBContext.StudentLectures.ToList();

            MainDataGrid5.ItemsSource = dataDBContext.StudentLectures.Local.ToObservableCollection();


            var txtcolumn5 = new DataGridTextColumn();
            txtcolumn5.Header = "MainDataGrid5";

            MainDataGrid5.Columns.Insert(0, txtcolumn5);


        }//end method


        public void GetUniversityofTony()
        {
            Student Tony = dataDBContext.Students.First(st => st.Name.Equals("Tony"));
            University TonyUniversity = Tony.University;

            // wont work --- MainDataGrid5.ItemsSource = TonyUniversity;
            List<University> universities = new List<University>();
            universities.Add(TonyUniversity);

          //  MainDataGrid5.ItemsSource = universities;


        }



        public void GetLecturesofTony()
        {


            Student Tony = dataDBContext.Students.First(st => st.Name.Equals("Tony"));

            //tudentLecture TonyStudentLectures = Tony.StudentLectures.
            //MainDataGrid6.ItemsSource = Tony.StudentLectures.;

            var tonylectures = from sl in Tony.StudentLectures select sl.Lecture;
            MainDataGrid6.ItemsSource = tonylectures;

            var txtcolumn6 = new DataGridTextColumn();
            txtcolumn6.Header = "MainDataGrid6";

            MainDataGrid6.Columns.Insert(0, txtcolumn6);





        }//emthod

        public void GetAllStudentsFromYale()
        {

            var studentsFromYale = from student in dataDBContext.Students where student.University.Name == "Yale" select student;
            MainDataGrid7.ItemsSource = studentsFromYale.ToList();

            var txtcolumn7 = new DataGridTextColumn();
            txtcolumn7.Header = "MainDataGrid7";

            MainDataGrid7.Columns.Insert(0, txtcolumn7);


        }// method

        public void GetAllUniversitiesWithTransgender()
        {

            var undiscloseduni = from student in dataDBContext.Students join university in dataDBContext.Universities 
                                 on student.University equals university where student.Gender == "undisclosed" select university;
            MainDataGrid8.ItemsSource = undiscloseduni.ToList();


            var txtcolumn8 = new DataGridTextColumn();
            txtcolumn8.Header = "MainDataGrid8";

            MainDataGrid8.Columns.Insert(0, txtcolumn8);



            /*I've wrote the linq query for GetAllUniversitiesWithTransgenders method differently without using join:

    var universities = from student in dataContext.Students
                        where student.Gender == "trans-gender"
                        select student.University;
            */


        }//emthod

        public void GetAllLecturesFromBeijingTech()
        {
            var lecturesFromBeijingTech = from sl in dataDBContext.StudentLectures join student in dataDBContext.Students on sl.StudentId equals student.Id
                                          where student.University.Name == "Beijing Tech" select sl.Lecture;
            MainDataGrid9.ItemsSource = lecturesFromBeijingTech.ToList();

            var allinfo = from student in dataDBContext.Students select student.University;
            MainDataGrid9.ItemsSource = allinfo.ToList();


            var undiscloseduni = from student in dataDBContext.Students join university in dataDBContext.Universities on student.UniversityId equals university.Id
                                 select new { v1 = student.Name, student.Gender, student.University.Name, v2=university.Name };
        //    MainDataGrid9.ItemsSource = undiscloseduni.ToList();


         var someobs=   ToObservableCollection(undiscloseduni);

            MainDataGrid9.ItemsSource = someobs;

            // var undiscloseduni1 = from student in dataDBContext.Students select student;
            //  MainDataGrid9.ItemsSource = undiscloseduni1.ToList();

            var txtcolumn9 = new DataGridTextColumn();
            txtcolumn9.Header = "MainDataGrid9";

            MainDataGrid9.Columns.Insert(0, txtcolumn9);




        }//mehtod

        public void UpdateStudent(string nameToBeUpdated, string newName)
        {

           
            Student studentToBeUpdated = dataDBContext.Students.FirstOrDefault(st => st.Name == $"{nameToBeUpdated}");
            studentToBeUpdated.Name = newName;
            dataDBContext.SaveChanges();
            Debug.Write("done");
        }//method


        public void DeleteStudent(string nameToBeUpdated)
        {

            Student studentToBeUpdated = dataDBContext.Students.FirstOrDefault(st => st.Name == $"{nameToBeUpdated}");
            dataDBContext.Remove(studentToBeUpdated);
            dataDBContext.SaveChanges();
            
            /*MainDataGrid9.Items.Refresh();
            
            MainDataGrid2.Items.Refresh();
            var str= MainDataGrid2.Items.ToString(); 
            */


            Debug.Write("done");
        }//method


        public ObservableCollection<T> ToObservableCollection<T>(IEnumerable<T> enumeration)
        {
            return new ObservableCollection<T>(enumeration);
        }


        public void GetAllStudentsWithUniversities()
        {
            var allStudentsJoinedWithUnis= from student in dataDBContext.Students
                                 join university in dataDBContext.Universities on student.UniversityId equals university.Id
                                 select new { v1 = student.Name, student.Gender, student.University.Name, v2 = university.Name };
            
            //MainDataGrid2_0.ItemsSource = allStudentsJoinedWithUnis.ToList();


            var someobs = ToObservableCollection(allStudentsJoinedWithUnis);

            MainDataGrid2_0.ItemsSource = someobs;
        }

        public void GetAllStudents()
        {
            MainDataGrid2_1.ItemsSource = dataDBContext.Students.Local.ToObservableCollection();
        }









    }
}
