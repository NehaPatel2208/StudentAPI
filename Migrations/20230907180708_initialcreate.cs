using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fees = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "StudentEnrolments",
                columns: table => new
                {
                    EnrolmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Semester = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrolments", x => x.EnrolmentId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "Fees", "StartingDate" },
                values: new object[,]
                {
                    { 1, "C#", 500, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, ".NET", 600, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "SQL Server", 800, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Angular", 700, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "StudentEnrolments",
                columns: new[] { "EnrolmentId", "CourseId", "RegisteredDate", "Semester", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fall 2023", 1 },
                    { 2, 1, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fall 2023", 2 },
                    { 3, 3, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fall 2023", 1 },
                    { 4, 4, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fall 2023", 1 },
                    { 5, 4, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring 2024", 2 },
                    { 6, 4, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring 2024", 3 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "DateOfBirth", "DepartmentId", "Email", "Firstname", "Gender", "Lastname" },
                values: new object[,]
                {
                    { 1, new DateTime(1996, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "neha2208patel@gmail.com", "Neha", 1, "Patel" },
                    { 2, new DateTime(1994, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "steveorth@gmail.com", "Steve", 0, "Orth" },
                    { 3, new DateTime(1993, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "natiajohn@gmail.com", "Natia", 1, "John" },
                    { 4, new DateTime(1995, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "samanthabarely@gmail.com", "Samantha", 1, "Barely" },
                    { 5, new DateTime(1996, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "zackperry@gmail.com", "Zack", 0, "Perry" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "StudentEnrolments");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
