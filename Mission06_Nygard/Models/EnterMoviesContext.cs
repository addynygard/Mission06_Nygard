using Microsoft.EntityFrameworkCore;

namespace Mission06_Nygard.Models
{
    public class EnterMoviesContext : DbContext
    {
        public EnterMoviesContext(DbContextOptions<EnterMoviesContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
