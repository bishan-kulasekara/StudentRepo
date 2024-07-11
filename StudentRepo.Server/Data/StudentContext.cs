using Microsoft.EntityFrameworkCore;
using StudentRepo.Server.Models;

namespace StudentRepo.Server.Data
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(s => s.ProfileImage)
                .HasColumnType("nvarchar(max)");
        }
    }
}
