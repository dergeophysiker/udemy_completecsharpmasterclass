using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Windows;
using System.Configuration;
using Microsoft.Data.Sqlite;
//using Microsoft.EntityFrameworkCore;


namespace testSQLliteMEF
{
    class Program
    {

        static void Main(string[] args)
        {

            /*
            Console.WriteLine("Hello World!");

           
            string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            SqliteConnection connection = new SqliteConnection(connectionString);

            connection.Open();

            string query = "SELECT SQLITE_VERSION()";

            var cmdo = new SqliteCommand(query, connection);
            
            string version = cmdo.ExecuteScalar().ToString();
            Console.WriteLine($"SQLite version: {version}");

            */

            /* using (var connection = new SqliteConnection("Data Source=DemoDB.db"))
             {
                 connection.Open();

                 var command = connection.CreateCommand();
                 command.CommandText =
                 @"
         SELECT Name
         FROM Artist
         WHERE ArtistId = $id
     ";
                 command.Parameters.AddWithValue("$id", 1);

                 using (var reader = command.ExecuteReader())
                 {
                     while (reader.Read())
                     {
                         var name = reader.GetString(0);

                         Console.WriteLine($"Hello, {name}!");
                     }
                 }
             }//close */

            /****************   skilpping all of this   */
            /* var connection = new SqliteConnection("Data Source=DemoDB.db;");

             connection.Open();

            var context = new ChinookContext();

            var artists = from a in context.Artists where a.ArtistId==1 select a;
           var fetchedDAta = artists.ToList();

             var albums = from b in context.Albums where b.AlbumId == 1 select b;
             var fetchedAlbum = albums.ToList();

           foreach (var artist in artists)
           {
               Console.WriteLine(artist.Name);

           }


           foreach(var alb in albums)
             {
                 Console.WriteLine(alb.Title);
             }


             connection.Close();


             */

            /// put new code below here
            /// 
            Console.WriteLine("begin");

            using (var context = new ChinookContext())
            {
                var artists = from a in context.Artists
                              where a.Name.StartsWith("A")
                              orderby a.Name
                              select a;

                foreach (var artist in artists)
                {
                    Console.WriteLine(artist.Name);
                }
            }

            Console.WriteLine("end");








        }//mmain
    }//program

    //==========================================================begin
    public class Artist
    {
        public Artist()
        {
            Albums = new List<Album>();
        }

        public long ArtistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }

    public class Album
    {
        public long AlbumId { get; set; }
        public string Title { get; set; }

        public long ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }

    class ChinookContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Chinook Database does not pluralize table names
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();
        }
    }

    //==========================================================end

    /* skipping all of this

    public class Artist
    {
        public Artist()
        {
            Albums = new List<Album>();
        }

        public long ArtistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }//atrist

    public class Album
    {
        public long AlbumId { get; set; }
        public string Title { get; set; }

        public long ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }//album

    class ChinookContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Chinook Database does not pluralize table names
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();
        }
    }//chinookContextg
    */

}
