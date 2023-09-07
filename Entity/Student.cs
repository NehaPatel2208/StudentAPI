using System;

namespace StudentAPI.Entity
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public enumGender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }

    }

    public enum enumGender
    {
        Male,
        Female,
        Others
    }
}
