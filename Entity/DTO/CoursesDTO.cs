using System;

namespace StudentAPI.Entity.DTO
{
    public class CoursesDTO
    {
        public string CourseName { get; set; }
        public DateTime StartingDate { get; set; }
        public int Fees { get; set; }

    }
}
