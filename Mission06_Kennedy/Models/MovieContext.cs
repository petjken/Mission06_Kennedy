using Microsoft.EntityFrameworkCore;
using Mission06_LastName.Models;

namespace Mission06_Kennedy.Models
{
    // This class is the "bridge" between your C# code and the SQLite database
    public class MovieContext : DbContext
    {
        // Constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        // This creates a "Movies" table in the database based on your Movie.cs model
        public DbSet<Movie> Movies { get; set; }
    }
}