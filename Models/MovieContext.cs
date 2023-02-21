using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_msperry6.Models
{
    public class MovieContext : DbContext
    {
        //Constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        //Seed data

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy"},
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family"},
                new Category { CategoryId = 5, CategoryName = "Horrer/Suspense"},
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                );

            mb.Entity<Movie>().HasData(

                new Movie
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "Intersteller",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""

                },
                new Movie
                {
                    Id = 2,
                    CategoryId = 1,
                    Title = "The Lord of the Rings: The Return of the King",
                    Year = 2003,
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new Movie
                {
                    Id = 3,
                    CategoryId = 2,
                    Title = "Fantastic Mr. Fox",
                    Year = 2009,
                    Director = "Wes Anderson",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
                );
        }
    }
}
