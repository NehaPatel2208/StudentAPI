using System;

namespace StudentAPI.Entity.DTO
{
    public class StudentDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public enumGender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }

    }

}
