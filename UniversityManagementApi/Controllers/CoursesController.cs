using Microsoft.AspNetCore.Mvc;
using UniversityManagementApi.DTOs.Courses;
using UniversityManagementApi.Services.Interfaces;

namespace UniversityManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAllAsync();

            return Ok(courses);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetById(
            [FromQuery] int id)
        {
            var course = await _courseService.GetByIdAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CourseCreateDto dto)
        {
            var course = await _courseService.AddAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = course.Id },
                course
            );
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            [FromQuery] int id,
            CourseUpdateDto dto)
        {
            var result = await _courseService.UpdateAsync(id, dto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(
            [FromQuery] int id)
        {
            var result = await _courseService.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("teacher")]
        public async Task<IActionResult> GetCoursesByTeacher(
            [FromQuery] int teacherId)
        {
            var courses =
                await _courseService.GetCoursesByTeacherAsync(teacherId);

            return Ok(courses);
        }

        [HttpGet("popular")]
        public async Task<IActionResult> GetMostPopularCourses(
            [FromQuery] int count)
        {
            var courses =
                await _courseService.GetMostPopularCoursesAsync(count);

            return Ok(courses);
        }

        [HttpGet("credit")]
        public async Task<IActionResult> GetCoursesByCredit(
            [FromQuery] int credit)
        {
            var courses =
                await _courseService.GetCoursesByCreditAsync(credit);

            return Ok(courses);
        }

        [HttpGet("ordered-by-credit")]
        public async Task<IActionResult> GetCoursesOrderedByCredit()
        {
            var courses =
                await _courseService.GetCoursesOrderedByCreditAsync();

            return Ok(courses);
        }

        [HttpGet("without-students")]
        public async Task<IActionResult> GetCoursesWithoutStudents()
        {
            var courses =
                await _courseService.GetCoursesWithoutStudentsAsync();

            return Ok(courses);
        }
    }
}