using Microsoft.EntityFrameworkCore;
using VoingPracticalTestData.Models;

namespace VoingPracticalTestData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
                : base(options)
        {
        }
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDetail>()
                .Property(e => e.CreatedOn)
                .HasDefaultValueSql("GETUTCDATE()"); // Set default value to current UTC date/time using Fluent API
            modelBuilder.Entity<UserLogin>()
               .Property(e => e.CreatedOn)
               .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}