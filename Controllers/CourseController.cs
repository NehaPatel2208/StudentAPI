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
    public class CourseController : Controller
    {
        private readonly ICourseRepository courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetCoursesBasedonStudentAndSemester([FromQuery] string studentName, [FromQuery] string semester)
        {
            try
            {
                var result = await courseRepository.GetCoursesBasedonStudentAndSemester(studentName, semester);
                if(result == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent,"Data not found for given Student name and Semester");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetAllCourses")]
        public async Task<ActionResult> GetAllCourses()
        {
            try
            {
               return Ok(await courseRepository.GetAllCourses());
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddCourse(CoursesDTO courseDto)
        {
            try
            {

                if (courseDto == null)
                    return BadRequest();
              
                return Ok(await courseRepository.AddCourse(courseDto));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
