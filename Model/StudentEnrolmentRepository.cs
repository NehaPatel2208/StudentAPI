using Microsoft.EntityFrameworkCore;
using StudentAPI.Entity;
using StudentAPI.Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAPI.Model
{
    public class StudentEnrolmentRepository : IStudentEnrolmentRepository
    {
        private readonly AppDbContext appDbContext;

        public StudentEnrolmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<StudentEnrolment>> GetAllEnrolments()
        {
            return await appDbContext.StudentEnrolments.ToListAsync();
        }

        public async Task<StudentEnrolment> AddStudentEnrolment(StudentEnrolmentDTO studentEnrolmentDto)
        {
            var studentEnrolment = new StudentEnrolment
            {
                CourseId = studentEnrolmentDto.CourseId,
                StudentId = studentEnrolmentDto.StudentId,
                Semester = studentEnrolmentDto.Semester,
                RegisteredDate = studentEnrolmentDto.RegisteredDate
            };
            var result = await appDbContext.StudentEnrolments.AddAsync(studentEnrolment);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
