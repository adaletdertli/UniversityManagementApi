using Microsoft.AspNetCore.Mvc;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;

namespace UniversityManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentRepository.GetAllAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            await _studentRepository.AddAsync(student);

            return CreatedAtAction(
                nameof(GetById),
                new { id = student.Id },
                student
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Student student)
        {
            var existingStudent = await _studentRepository.GetByIdAsync(id);

            if (existingStudent == null)
            {
                return NotFound();
            }

            student.Id = id;

            await _studentRepository.UpdateAsync(student);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            await _studentRepository.DeleteAsync(student);

            return NoContent();
        }

        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetStudentsByCourse(int courseId)
        {
            var students = await _studentRepository.GetStudentsByCourseAsync(courseId);

            return Ok(students);
        }

        [HttpGet("{studentId}/courses")]
        public async Task<IActionResult> GetStudentCourses(int studentId)
        {
            var courses = await _studentRepository.GetStudentCoursesAsync(studentId);

            return Ok(courses);
        }

        [HttpGet("{studentId}/average")]
        public async Task<IActionResult> GetStudentAverage(int studentId)
        {
            var average = await _studentRepository.GetStudentAverageAsync(studentId);

            if (average == null)
            {
                return NotFound();
            }

            return Ok(average);
        }

        [HttpGet("top/{count}")]
        public async Task<IActionResult> GetTopStudents(int count)
        {
            var students = await _studentRepository.GetTopStudentsAsync(count);

            return Ok(students);
        }
    }
}