using Microsoft.EntityFrameworkCore;

namespace Mission06_Nygard.Models
// Creates a context for the database
{
    public class EnterMoviesContext : DbContext
    {
        // Constructor that takes in a DbContextOptions object and assigns it to the base class
        public EnterMoviesContext(DbContextOptions<EnterMoviesContext> options) : base(options)
        {
        }
        // Creates a DbSet of Movie objects
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; } // does this need to be DbSet<Category> Categories????

        // 
        protected override void OnModelCreating(ModelBuilder modelBuilder) // this is how to seed the data
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 2, CategoryName = "Drama" },
                new Category { CategoryId = 3, CategoryName = "Television" },
                new Category { CategoryId = 4, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 5, CategoryName = "Comedy" },
                new Category { CategoryId = 6, CategoryName = "Family" },
                new Category { CategoryId = 7, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );
            // go in and check to see if there is data type catoegories in the database, we don't want to readd it; this will put data in
        }

    }
}
