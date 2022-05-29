using Microsoft.EntityFrameworkCore;
using Test6.Models;

namespace Test6.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Smer> Smerovi { get; set; }
        public DbSet<Student> Studenti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Smer>();
            modelBuilder.Entity<Student>();


            modelBuilder.Entity<Smer>()
                 .HasMany(c => c.Studenti)
                 .WithOne(e => e.Smer);

        }
    }
}
