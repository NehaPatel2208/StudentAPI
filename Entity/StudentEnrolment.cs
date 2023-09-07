using System;
using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Entity
{
    public class StudentEnrolment
    {
        [Key]
        public int EnrolmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Semester { get; set; }
    }
}
