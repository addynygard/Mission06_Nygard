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
    }
}
