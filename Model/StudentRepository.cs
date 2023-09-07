using Microsoft.EntityFrameworkCore;
using StudentAPI.Entity;
using StudentAPI.Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAPI.Model
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Student> AddStudent(StudentDTO studentDto)
        {
            var student = new Student
            {
                Firstname = studentDto.Firstname,
                Lastname = studentDto.Lastname,
                DateOfBirth = studentDto.DateOfBirth,
                DepartmentId = studentDto.DepartmentId,
                Gender = studentDto.Gender,
                Email = studentDto.Email,
            };
            var result = await appDbContext.Students.AddAsync(student);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteStudent(int studentId)
        {
            var result = await appDbContext.Students.FirstOrDefaultAsync(student => student.StudentId == studentId);
            if(result != null)
            {
                appDbContext.Students.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Student> GetStudent(int studentId)
        {
            return await appDbContext.Students.FirstOrDefaultAsync(student => student.StudentId == studentId);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await appDbContext.Students.ToListAsync();
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var result = await appDbContext.Students.FirstOrDefaultAsync(data => data.StudentId == student.StudentId);

            if(result != null)
            {
                result.Firstname = student.Firstname;
                result.Lastname = student.Lastname;
                result.DateOfBirth = student.DateOfBirth;
                result.DepartmentId = student.DepartmentId;
                result.Gender = student.Gender;
                result.Email = student.Email;
            }

            await appDbContext.SaveChangesAsync();
            return result;
        }

    }
}
