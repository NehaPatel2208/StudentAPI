using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Entity;
using StudentAPI.Entity.DTO;
using StudentAPI.Model;
using System;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;
        
        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        
        [HttpGet("GetAllStudents")]
        public async Task<ActionResult> GetStudents()
        {
            try
            {
                var result = await studentRepository.GetStudents();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetStudent")]
        public async Task<ActionResult> GetStudent([FromQuery] int studentId)
        {
            try
            {
                var result = await studentRepository.GetStudent(studentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ObjectResult> DeleteStudent([FromQuery] int studentId)
        {
            try
            {
                await studentRepository.DeleteStudent(studentId);
                return StatusCode(StatusCodes.Status200OK, "Delete successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent(StudentDTO student)
        {
            try
            {
                if (student == null)
                    return BadRequest();
             
                return  Ok(await studentRepository.AddStudent(student));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStudent(Student student)
        {
            try
            {
                if (student == null)
                    return BadRequest();

                var studentResult = await studentRepository.GetStudent(student.StudentId);
                if(studentResult == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, "Student not found");
                }
                return Ok(await studentRepository.UpdateStudent(student));
               

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

       
    }
}
