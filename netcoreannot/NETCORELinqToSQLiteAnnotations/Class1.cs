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

            InsertUniversities();
            InsertStudent();

            GetAllStudentsWithUniversities();
            GetAllStudents();

            DeleteStudent("James");

        }


        public void InsertUniversities()
        {
            University yale = new University();
            yale.Name = "Yale";
            dataDBContext.Universities.Add(yale);

            University beijingTech = new University();
            beijingTech.Name = "Beijing Tech";
            dataDBContext.Universities.Add(beijingTech);

            dataDBContext.SaveChanges();

        }

        public void InsertStudent()
        {
            University yale = dataDBContext.Universities.First(un => un.Name.Equals("Yale"));
            University beijingTech = dataDBContext.Universities.First(un => un.Name.Equals("Beijing Tech"));

            List<Student> students = new List<Student>();

            students.Add(new Student { Name = "Carla", Gender = "female", UniversityId = yale.Id });
            students.Add(new Student { Name = "Tony", Gender = "male", University = yale });
            students.Add(new Student { Name = "James", Gender = "undisclosed", University = beijingTech });
             
           dataDBContext.Students.AddRange(students);
           dataDBContext.SaveChanges();
        }



        public void DeleteStudent(string nameToBeUpdated)
        {

            Student studentToBeUpdated = dataDBContext.Students.FirstOrDefault(st => st.Name == $"{nameToBeUpdated}");
            dataDBContext.Remove(studentToBeUpdated);
            dataDBContext.SaveChanges();

        }



        public void GetAllStudentsWithUniversities()
        {
            var allStudentsJoinedWithUnis = from student in dataDBContext.Students
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


        public ObservableCollection<T> ToObservableCollection<T>(IEnumerable<T> enumeration)
        {
            return new ObservableCollection<T>(enumeration);
        }






    }
}
