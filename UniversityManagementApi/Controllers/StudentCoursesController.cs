using Microsoft.AspNetCore.Mvc;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;

namespace UniversityManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentCoursesController : ControllerBase
    {
        private readonly IStudentCourseRepository _studentCourseRepository;

        public StudentCoursesController(
            IStudentCourseRepository studentCourseRepository)
        {
            _studentCourseRepository = studentCourseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var studentCourses =
                await _studentCourseRepository.GetAllAsync();

            return Ok(studentCourses);
        }

        [HttpGet("{studentId}/{courseId}")]
        public async Task<IActionResult> GetById(
            int studentId,
            int courseId)
        {
            var studentCourse =
                await _studentCourseRepository.GetByIdAsync(
                    studentId,
                    courseId
                );

            if (studentCourse == null)
            {
                return NotFound();
            }

            return Ok(studentCourse);
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudentCourse studentCourse)
        {
            await _studentCourseRepository.AddAsync(studentCourse);

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

        [HttpPut("{studentId}/{courseId}")]
        public async Task<IActionResult> Update(
            int studentId,
            int courseId,
            StudentCourse studentCourse)
        {
            var existingStudentCourse =
                await _studentCourseRepository.GetByIdAsync(
                    studentId,
                    courseId
                );

            if (existingStudentCourse == null)
            {
                return NotFound();
            }

            studentCourse.StudentId = studentId;
            studentCourse.CourseId = courseId;

            await _studentCourseRepository.UpdateAsync(studentCourse);

            return NoContent();
        }

        [HttpDelete("{studentId}/{courseId}")]
        public async Task<IActionResult> Delete(
            int studentId,
            int courseId)
        {
            var studentCourse =
                await _studentCourseRepository.GetByIdAsync(
                    studentId,
                    courseId
                );

            if (studentCourse == null)
            {
                return NotFound();
            }

            await _studentCourseRepository.DeleteAsync(studentCourse);

            return NoContent();
        }
    }
}