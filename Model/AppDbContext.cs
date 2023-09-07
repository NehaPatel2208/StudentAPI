using Microsoft.EntityFrameworkCore;
using StudentAPI.Entity;
using System;

namespace StudentAPI.Model
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<StudentEnrolment> StudentEnrolments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Student data
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    Firstname = "Neha",
                    Lastname = "Patel",
                    DateOfBirth = new DateTime(1996,8,22),
                    Email = "neha2208patel@gmail.com",
                    Gender = enumGender.Female,
                    DepartmentId = 1
                }) ;

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 2,
                    Firstname = "Steve",
                    Lastname = "Orth",
                    DateOfBirth = new DateTime(1994, 5, 9),
                    Email = "steveorth@gmail.com",
                    Gender = enumGender.Male,
                    DepartmentId = 3
                });
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 3,
                    Firstname = "Natia",
                    Lastname = "John",
                    DateOfBirth = new DateTime(1993, 11, 10),
                    Email = "natiajohn@gmail.com",
                    Gender = enumGender.Female,
                    DepartmentId = 1
                });
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 4,
                    Firstname = "Samantha",
                    Lastname = "Barely",
                    DateOfBirth = new DateTime(1995, 10, 2),
                    Email = "samanthabarely@gmail.com",
                    Gender = enumGender.Female,
                    DepartmentId = 2
                });
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 5,
                    Firstname = "Zack",
                    Lastname = "Perry",
                    DateOfBirth = new DateTime(1996, 10, 5),
                    Email = "zackperry@gmail.com",
                    Gender = enumGender.Male,
                    DepartmentId = 2
                });

            // Course data

            modelBuilder.Entity<Courses>().HasData(
                new Courses
                {
                    CourseId = 1,
                    CourseName = "C#",
                    StartingDate =  new DateTime(2023, 9, 15),
                    Fees= 500
                });

            modelBuilder.Entity<Courses>().HasData(
                new Courses
                {
                    CourseId = 2,
                    CourseName = ".NET",
                    StartingDate = new DateTime(2023, 9, 10),
                    Fees = 600
                });

            modelBuilder.Entity<Courses>().HasData(
                new Courses
                {
                    CourseId = 3,
                    CourseName = "SQL Server",
                    StartingDate = new DateTime(2023, 9, 15),
                    Fees = 800
                });

            modelBuilder.Entity<Courses>().HasData(
                new Courses
                {
                    CourseId = 4,
                    CourseName = "Angular",
                    StartingDate = new DateTime(2023, 9, 10),
                    Fees = 700
                });

            // Student enrolment data
            modelBuilder.Entity<StudentEnrolment>().HasData(
               new StudentEnrolment
               {
                   EnrolmentId = 1,
                   CourseId = 1,
                   StudentId = 1,
                   Semester = "Fall 2023",
                   RegisteredDate = new DateTime(2023, 9, 1)
               });

            modelBuilder.Entity<StudentEnrolment>().HasData(
              new StudentEnrolment
              {
                  EnrolmentId = 2,
                  CourseId = 1,
                  StudentId = 2,
                  Semester = "Fall 2023",
                  RegisteredDate = new DateTime(2023, 9, 1)
              });

            modelBuilder.Entity<StudentEnrolment>().HasData(
              new StudentEnrolment
              {
                  EnrolmentId = 3,
                  CourseId = 3,
                  StudentId = 1,
                  Semester = "Fall 2023",
                  RegisteredDate = new DateTime(2023, 9, 1)
              });

            modelBuilder.Entity<StudentEnrolment>().HasData(
              new StudentEnrolment
              {
                  EnrolmentId = 4,
                  CourseId = 4,
                  StudentId = 1,
                  Semester = "Fall 2023",
                  RegisteredDate = new DateTime(2023, 9, 1)
              });

            modelBuilder.Entity<StudentEnrolment>().HasData(
             new StudentEnrolment
             {
                 EnrolmentId = 5,
                 CourseId = 4,
                 StudentId = 2,
                 Semester = "Spring 2024",
                 RegisteredDate = new DateTime(2023, 9, 1)
             });

            modelBuilder.Entity<StudentEnrolment>().HasData(
             new StudentEnrolment
             {
                 EnrolmentId = 6,
                 CourseId = 4,
                 StudentId = 3,
                 Semester = "Spring 2024",
                 RegisteredDate = new DateTime(2023, 9, 1)
             });
        }
    }
}
