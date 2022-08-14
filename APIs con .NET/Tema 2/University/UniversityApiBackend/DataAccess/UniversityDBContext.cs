using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.DataAccess
{
    public class UniversityDBContext: DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options): base(options) { }

        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(course => course.Level)
                .HasConversion<string>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
