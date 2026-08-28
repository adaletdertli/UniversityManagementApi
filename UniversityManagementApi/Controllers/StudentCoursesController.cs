using Microsoft.AspNetCore.Mvc;
using UniversityManagementApi.DTOs.StudentCourses;
using UniversityManagementApi.Services.Interfaces;

namespace UniversityManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentCoursesController : ControllerBase
    {
        private readonly IStudentCourseService _studentCourseService;

        public StudentCoursesController(
            IStudentCourseService studentCourseService)
        {
            _studentCourseService = studentCourseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var studentCourses =
                await _studentCourseService.GetAllAsync();

            return Ok(studentCourses);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetById(
            [FromQuery] int studentId,
            [FromQuery] int courseId)
        {
            var studentCourse =
                await _studentCourseService.GetByIdAsync(
                    studentId,
                    courseId);

            if (studentCourse == null)
            {
                return NotFound();
            }

            return Ok(studentCourse);
        }

        [HttpPost]
        public async Task<IActionResult> Add(
            StudentCourseCreateDto dto)
        {
            var studentCourse =
                await _studentCourseService.AddAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    studentId = studentCourse.StudentId,
                    courseId = studentCourse.CourseId
                },
                studentCourse
            );
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            [FromQuery] int studentId,
            [FromQuery] int courseId,
            StudentCourseUpdateDto dto)
        {
            var result =
                await _studentCourseService.UpdateAsync(
                    studentId,
                    courseId,
                    dto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(
            [FromQuery] int studentId,
            [FromQuery] int courseId)
        {
            var result =
                await _studentCourseService.DeleteAsync(
                    studentId,
                    courseId);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("grade")]
        public async Task<IActionResult> GetByMinimumGrade(
            [FromQuery] double grade)
        {
            var studentCourses =
                await _studentCourseService.GetByMinimumGradeAsync(grade);

            return Ok(studentCourses);
        }

        [HttpGet("highest-grade")]
        public async Task<IActionResult> GetHighestGrade()
        {
            var grade =
                await _studentCourseService.GetHighestGradeAsync();

            if (grade == null)
            {
                return NotFound();
            }

            return Ok(grade);
        }

        [HttpGet("lowest-grade")]
        public async Task<IActionResult> GetLowestGrade()
        {
            var grade =
                await _studentCourseService.GetLowestGradeAsync();

            if (grade == null)
            {
                return NotFound();
            }

            return Ok(grade);
        }

        [HttpGet("student-course-count")]
        public async Task<IActionResult> GetCourseCountByStudent(
            [FromQuery] int studentId)
        {
            var count =
                await _studentCourseService.GetCourseCountByStudentAsync(studentId);

            return Ok(count);
        }
    }
}