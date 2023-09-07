using Microsoft.EntityFrameworkCore;
using StudentAPI.Entity;
using StudentAPI.Entity.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Model
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext appDbContext;

        public CourseRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        // Get all courses base on given student and given semester
        public async Task<IEnumerable<Courses>> GetCoursesBasedonStudentAndSemester(string studentName, string semester)
        {
            // Get studentId from student name.
            var student = (await appDbContext.Students.FirstOrDefaultAsync(student => student.Firstname == studentName));

            if (student != null)
            {
                // Get all courseId from StudentEnrolment dataset.
                var courseId = await appDbContext.StudentEnrolments.Where(data => data.StudentId == student.StudentId && data.Semester == semester).Select(data => data.CourseId).ToListAsync();

                if (courseId.Any())
                {
                    // Get all course details from courseId
                    return await appDbContext.Courses.Where(data => courseId.Contains(data.CourseId)).ToListAsync();
                }
            }

            return null;
        }

        public async Task<IEnumerable<Courses>> GetAllCourses()
        {
            return await appDbContext.Courses.ToListAsync();
        }

        public async Task<Courses> AddCourse(CoursesDTO courseDto)
        {
            var course = new Courses
            {
                CourseName = courseDto.CourseName,
                StartingDate = courseDto.StartingDate,
                Fees = courseDto.Fees,
            };

            var result = await appDbContext.Courses.AddAsync(course);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
