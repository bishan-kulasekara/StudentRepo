using Microsoft.EntityFrameworkCore;
using StudentRepo.Server.Models;

namespace StudentRepo.Server.Data
{
    public class StudentContext : DbContext
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
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Bob",
                    LastName = "Brown",
                    Mobile = "2233445566",
                    Email = "bob.brown@example.com",
                    NIC = "223344556V",
                    DateOfBirth = new DateTime(1998, 4, 4),
                    Address = "101 Maple St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 5,
                    FirstName = "Charlie",
                    LastName = "Davis",
                    Mobile = "3344556677",
                    Email = "charlie.davis@example.com",
                    NIC = "334455667V",
                    DateOfBirth = new DateTime(1997, 5, 5),
                    Address = "202 Cedar St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 6,
                    FirstName = "Diana",
                    LastName = "Evans",
                    Mobile = "4455667788",
                    Email = "diana.evans@example.com",
                    NIC = "445566778V",
                    DateOfBirth = new DateTime(2002, 6, 6),
                    Address = "303 Birch St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 7,
                    FirstName = "Edward",
                    LastName = "Frank",
                    Mobile = "5566778899",
                    Email = "edward.frank@example.com",
                    NIC = "556677889V",
                    DateOfBirth = new DateTime(1996, 7, 7),
                    Address = "404 Spruce St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 8,
                    FirstName = "Fiona",
                    LastName = "Green",
                    Mobile = "6677889900",
                    Email = "fiona.green@example.com",
                    NIC = "667788990V",
                    DateOfBirth = new DateTime(2003, 8, 8),
                    Address = "505 Elm St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 9,
                    FirstName = "George",
                    LastName = "Harris",
                    Mobile = "7788990011",
                    Email = "george.harris@example.com",
                    NIC = "778899001V",
                    DateOfBirth = new DateTime(2004, 9, 9),
                    Address = "606 Ash St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 10,
                    FirstName = "Hannah",
                    LastName = "Iverson",
                    Mobile = "8899001122",
                    Email = "hannah.iverson@example.com",
                    NIC = "889900112V",
                    DateOfBirth = new DateTime(2005, 10, 10),
                    Address = "707 Willow St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 11,
                    FirstName = "Ian",
                    LastName = "Jackson",
                    Mobile = "9900112233",
                    Email = "ian.jackson@example.com",
                    NIC = "990011223V",
                    DateOfBirth = new DateTime(1995, 11, 11),
                    Address = "808 Poplar St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 12,
                    FirstName = "Julia",
                    LastName = "King",
                    Mobile = "0011223344",
                    Email = "julia.king@example.com",
                    NIC = "001122334V",
                    DateOfBirth = new DateTime(2006, 12, 12),
                    Address = "909 Walnut St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 13,
                    FirstName = "Kevin",
                    LastName = "Lewis",
                    Mobile = "1122334455",
                    Email = "kevin.lewis@example.com",
                    NIC = "112233445V",
                    DateOfBirth = new DateTime(1994, 1, 13),
                    Address = "1010 Cherry St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 14,
                    FirstName = "Laura",
                    LastName = "Miller",
                    Mobile = "2233445566",
                    Email = "laura.miller@example.com",
                    NIC = "223344556V",
                    DateOfBirth = new DateTime(2007, 2, 14),
                    Address = "1111 Pineapple St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 15,
                    FirstName = "Michael",
                    LastName = "Nelson",
                    Mobile = "3344556677",
                    Email = "michael.nelson@example.com",
                    NIC = "334455667V",
                    DateOfBirth = new DateTime(2008, 3, 15),
                    Address = "1212 Coconut St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 16,
                    FirstName = "Nina",
                    LastName = "Olsen",
                    Mobile = "4455667788",
                    Email = "nina.olsen@example.com",
                    NIC = "445566778V",
                    DateOfBirth = new DateTime(2009, 4, 16),
                    Address = "1313 Orange St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 17,
                    FirstName = "Oscar",
                    LastName = "Perez",
                    Mobile = "5566778899",
                    Email = "oscar.perez@example.com",
                    NIC = "556677889V",
                    DateOfBirth = new DateTime(2010, 5, 17),
                    Address = "1414 Lemon St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 18,
                    FirstName = "Paula",
                    LastName = "Quinn",
                    Mobile = "6677889900",
                    Email = "paula.quinn@example.com",
                    NIC = "667788990V",
                    DateOfBirth = new DateTime(2011, 6, 18),
                    Address = "1515 Grapefruit St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 19,
                    FirstName = "Quincy",
                    LastName = "Roberts",
                    Mobile = "7788990011",
                    Email = "quincy.roberts@example.com",
                    NIC = "778899001V",
                    DateOfBirth = new DateTime(2012, 7, 19),
                    Address = "1616 Watermelon St, Anytown, USA",
                    ProfileImage = ""
                },
                new Student
                {
                    Id = 20,
                    FirstName = "Rachel",
                    LastName = "Smith",
                    Mobile = "8899001122",
                    Email = "rachel.smith@example.com",
                    NIC = "889900112V",
                    DateOfBirth = new DateTime(2013, 8, 20),
                    Address = "1717 Blueberry St, Anytown, USA",
                    ProfileImage = ""
                }
            );
        }
    }
}
