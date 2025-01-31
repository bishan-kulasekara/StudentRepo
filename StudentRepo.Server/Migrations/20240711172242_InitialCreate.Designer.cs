﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentRepo.Server.Data;

#nullable disable

namespace StudentRepo.Server.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20240711172242_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentRepo.Server.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("NIC")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St, Anytown, USA",
                            DateOfBirth = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Mobile = "1234567890",
                            NIC = "123456789V",
                            ProfileImage = ""
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Oak St, Anytown, USA",
                            DateOfBirth = new DateTime(2001, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane.doe@example.com",
                            FirstName = "Jane",
                            LastName = "Doe",
                            Mobile = "0987654321",
                            NIC = "987654321V",
                            ProfileImage = ""
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Pine St, Anytown, USA",
                            DateOfBirth = new DateTime(1999, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alice.smith@example.com",
                            FirstName = "Alice",
                            LastName = "Smith",
                            Mobile = "1122334455",
                            NIC = "112233445V",
                            ProfileImage = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
