using StudentAPI.Entity;
using StudentAPI.Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAPI.Model
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int StudentId);
        Task<Student> AddStudent(StudentDTO student);
        Task<Student> UpdateStudent(Student student);
        Task DeleteStudent(int StudentId);

    }
}
