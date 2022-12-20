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
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LinqToSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    //[Table(Name = "Animal")]
    public class Animal  {
      //  [Column(Name = "Id")]
        public int Id { get; set; }

       // [Column(Name = "Name")]
        public string Name { get; set; }
        
        public Animal()
        {

        }


    }//public

    public class Person
    {
        public int Id { get; set; }

        // [Column(Name = "Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person()
        {

        }


    }//person

    class PersonContext : DbContext
    {
      
        public PersonContext() : base("name=Default")
        {
        }

        public DbSet<Person> Persons { get; set; }

    }

    
    public partial class MainWindow : Window
    {

        SQLiteConnection con;
        

        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            con = new SQLiteConnection(connectionString);
            con.Open();

            string query = "SELECT SQLITE_VERSION()";

            var cmd = new SQLiteCommand(query, con);
            string version = cmd.ExecuteScalar().ToString();
            MessageBox.Show($"SQLite version: {version}");

           
       
            using (var context = new PersonContext())
            {
                var queryN1 = from c in context.Persons where c.Id == 1 select c;
                foreach (var c in queryN1)
                {

                    Console.WriteLine(c.Id);
                }
            }



            /*  https://answers.unity.com/questions/1814014/using-linq-with-sqlite.html
             * DataContext context = new DataContext(con);
               Table<Animal> Animal = context.GetTable<Animal>();

            var queryN1 = from c in context where c.Id == 1 select c;
            foreach(var c in queryN1)
            {

                Console.WriteLine(c.Id);
            }
            */

            // LinqToSqlDataClassessDataContext dataContext
            // dataContext = new LinqToSqlDataClassesDataContext(connectionString)




        }
    }
}

