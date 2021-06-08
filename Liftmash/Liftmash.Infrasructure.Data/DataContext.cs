using Liftmash.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Liftmash.Infrasructure.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Materials> Materials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materials>(e => e.HasIndex(p => p.Name));
            modelBuilder.Entity<Materials>(e => e.HasIndex(p => p.Article));
            modelBuilder.Entity<Materials>(e => e.HasIndex(p => p.Code));
        }
    }
}
