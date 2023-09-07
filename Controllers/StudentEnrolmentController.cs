using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Entity.DTO;
using StudentAPI.Model;
using System;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentEnrolmentController : Controller
    {
        private readonly IStudentEnrolmentRepository studentEnrolmentRepository;
        public StudentEnrolmentController(IStudentEnrolmentRepository studentEnrolmentRepository)
        {
            this.studentEnrolmentRepository = studentEnrolmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEnrolments()
        {
            try
            {
                return Ok(await studentEnrolmentRepository.GetAllEnrolments());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddEnrolments(StudentEnrolmentDTO studentEnrolmentDto)
        {
            try
            {

                if (studentEnrolmentDto == null)
                    return BadRequest();

                return Ok(await studentEnrolmentRepository.AddStudentEnrolment(studentEnrolmentDto));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
