using System;

namespace StudentAPI.Entity.DTO
{
    public class StudentEnrolmentDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Semester { get; set; }
    }
}
