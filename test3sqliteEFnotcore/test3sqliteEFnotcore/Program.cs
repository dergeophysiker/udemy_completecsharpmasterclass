using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Data;
using System.Linq;

//https://cs.wellesley.edu/~cs304/lectures/sqlite/


//https://www.bricelam.net/2012/10/entity-framework-on-sqlite.html


namespace test3sqliteEFnotcore
{

    class Program
    {
        static void Main(string[] args)
        {
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

        }
    }

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


}

