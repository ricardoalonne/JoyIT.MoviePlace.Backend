using JoyIT.MoviePlace.Entity;
using Microsoft.EntityFrameworkCore;

namespace JoyIT.MoviePlace.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
    }
}
