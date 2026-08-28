using Microsoft.AspNetCore.Mvc;
using UniversityManagementApi.DTOs.Teachers;
using UniversityManagementApi.Services.Interfaces;

namespace UniversityManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _teacherService.GetAllAsync();

            return Ok(teachers);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetById(
            [FromQuery] int id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TeacherCreateDto dto)
        {
            var teacher = await _teacherService.AddAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = teacher.Id },
                teacher
            );
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            [FromQuery] int id,
            TeacherUpdateDto dto)
        {
            var result = await _teacherService.UpdateAsync(id, dto);

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
            var result = await _teacherService.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("department")]
        public async Task<IActionResult> GetTeachersByDepartment(
            [FromQuery] int departmentId)
        {
            var teachers =
                await _teacherService.GetTeachersByDepartmentAsync(departmentId);

            return Ok(teachers);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchTeachers(
            [FromQuery] string name)
        {
            var teachers =
                await _teacherService.SearchTeachersAsync(name);

            return Ok(teachers);
        }
    }
}