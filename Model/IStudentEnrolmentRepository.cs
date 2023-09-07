using StudentAPI.Entity;
using StudentAPI.Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAPI.Model
{
    public interface IStudentEnrolmentRepository
    {
        Task<IEnumerable<StudentEnrolment>> GetAllEnrolments();
        Task<StudentEnrolment> AddStudentEnrolment(StudentEnrolmentDTO studentEnrolmentDto);
    }
}
