using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

namespace test5sqlliteEFcoremusicsqlite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var context = new ChinookContext())
            {
                var artistppl = from a in context.Artists
                              where a.Name.StartsWith("A")
                              orderby a.Name
                              select a;

                foreach (var temp in artistppl)
                {
                    Console.WriteLine(temp.Name);
                }
            }
        }//main

    }//program class

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=.\Chinook_Sqlite_AutoIncrementPKs.sqlite;");
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //     
            modelBuilder.RemovePluralizingTableNameConvention();
            base.OnModelCreating(modelBuilder);

        }



    }//end chinook class



public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                //entity.Relational().TableName = entity.DisplayName();
                entity.SetTableName(entity.DisplayName());
            }
        }
    }



}//solution class
