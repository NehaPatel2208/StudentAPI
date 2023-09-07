using StudentAPI.Entity;
using StudentAPI.Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAPI.Model
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Courses>> GetCoursesBasedonStudentAndSemester(string studentName, string semester);
        Task<IEnumerable<Courses>> GetAllCourses();
        Task<Courses> AddCourse(CoursesDTO course);
    }
}
