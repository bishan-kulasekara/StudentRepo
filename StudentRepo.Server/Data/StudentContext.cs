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

            // Seed data
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Mobile = "1234567890",
                    Email = "john.doe@example.com",
                    NIC = "123456789V",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    Address = "123 Main St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Mobile = "0987654321",
                    Email = "jane.doe@example.com",
                    NIC = "987654321V",
                    DateOfBirth = new DateTime(2001, 2, 2),
                    Address = "456 Oak St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Alice",
                    LastName = "Smith",
                    Mobile = "1122334455",
                    Email = "alice.smith@example.com",
                    NIC = "112233445V",
                    DateOfBirth = new DateTime(1999, 3, 3),
                    Address = "789 Pine St, Anytown, USA",
                    ProfileImage = ""
                }
            );
        }
    }
}
