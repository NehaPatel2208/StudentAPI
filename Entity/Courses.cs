using System;
using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Entity
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime StartingDate { get; set; }
        public int Fees { get; set; }

    }
}
