using Microsoft.AspNetCore.Mvc;
using UniversityManagementApi.DTOs.Departments;
using UniversityManagementApi.Services.Interfaces;

namespace UniversityManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetAllAsync();

            return Ok(departments);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetById(
            [FromQuery] int id)
        {
            var department = await _departmentService.GetByIdAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DepartmentCreateDto dto)
        {
            var department = await _departmentService.AddAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = department.Id },
                department
            );
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            [FromQuery] int id,
            DepartmentUpdateDto dto)
        {
            var result = await _departmentService.UpdateAsync(id, dto);

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
            var result = await _departmentService.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("ordered-by-teacher-count")]
        public async Task<IActionResult> GetDepartmentsOrderedByTeacherCount()
        {
            var departments =
                await _departmentService.GetDepartmentsOrderedByTeacherCountAsync();

            return Ok(departments);
        }

        [HttpGet("without-teachers")]
        public async Task<IActionResult> GetDepartmentsWithoutTeachers()
        {
            var departments =
                await _departmentService.GetDepartmentsWithoutTeachersAsync();

            return Ok(departments);
        }
    }
}