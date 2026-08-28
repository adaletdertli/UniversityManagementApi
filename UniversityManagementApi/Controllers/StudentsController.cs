using Microsoft.AspNetCore.Mvc;
using UniversityManagementApi.DTOs.Students;
using UniversityManagementApi.Services.Interfaces;

namespace UniversityManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();

            return Ok(students);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetById(
            [FromQuery] int id)
        {
            var student = await _studentService.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudentCreateDto dto)
        {
            var student = await _studentService.AddAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = student.Id },
                student
            );
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            [FromQuery] int id,
            StudentUpdateDto dto)
        {
            var result = await _studentService.UpdateAsync(id, dto);

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
            var result = await _studentService.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("course")]
        public async Task<IActionResult> GetStudentsByCourse(
            [FromQuery] int courseId)
        {
            var students =
                await _studentService.GetStudentsByCourseAsync(courseId);

            return Ok(students);
        }

        [HttpGet("courses")]
        public async Task<IActionResult> GetStudentCourses(
            [FromQuery] int studentId)
        {
            var courses =
                await _studentService.GetStudentCoursesAsync(studentId);

            return Ok(courses);
        }

        [HttpGet("average")]
        public async Task<IActionResult> GetStudentAverage(
            [FromQuery] int studentId)
        {
            var average =
                await _studentService.GetStudentAverageAsync(studentId);

            if (average == null)
            {
                return NotFound();
            }

            return Ok(average);
        }

        [HttpGet("top")]
        public async Task<IActionResult> GetTopStudents(
            [FromQuery] int count)
        {
            var students =
                await _studentService.GetTopStudentsAsync(count);

            return Ok(students);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchStudents(
            [FromQuery] string name)
        {
            var students =
                await _studentService.SearchStudentsAsync(name);

            return Ok(students);
        }

        [HttpGet("number")]
        public async Task<IActionResult> GetStudentsByStudentNumber(
            [FromQuery] string prefix)
        {
            var students =
                await _studentService.GetStudentsByStudentNumberAsync(prefix);

            return Ok(students);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetStudentsPaged(
            [FromQuery] int skip,
            [FromQuery] int take)
        {
            var students =
                await _studentService.GetStudentsPagedAsync(skip, take);

            return Ok(students);
        }

        [HttpGet("ordered")]
        public async Task<IActionResult> GetStudentsOrderedByName()
        {
            var students =
                await _studentService.GetStudentsOrderedByNameAsync();

            return Ok(students);
        }

        [HttpGet("first")]
        public async Task<IActionResult> GetFirstStudents(
            [FromQuery] int count)
        {
            var students =
                await _studentService.GetFirstStudentsAsync(count);

            return Ok(students);
        }

        [HttpGet("min-grade")]
        public async Task<IActionResult> GetStudentsByMinGrade(
            [FromQuery] double grade)
        {
            var students =
                await _studentService.GetStudentsByMinGradeAsync(grade);

            return Ok(students);
        }
    }
}