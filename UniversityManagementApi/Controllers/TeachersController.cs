using Microsoft.AspNetCore.Mvc;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;

namespace UniversityManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeachersController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _teacherRepository.GetAllAsync();

            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Teacher teacher)
        {
            await _teacherRepository.AddAsync(teacher);

            return CreatedAtAction(
                nameof(GetById),
                new { id = teacher.Id },
                teacher
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Teacher teacher)
        {
            var existingTeacher =
                await _teacherRepository.GetByIdAsync(id);

            if (existingTeacher == null)
            {
                return NotFound();
            }

            teacher.Id = id;

            await _teacherRepository.UpdateAsync(teacher);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            await _teacherRepository.DeleteAsync(teacher);

            return NoContent();
        }
    }
}