using Microsoft.AspNetCore.Mvc;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;

namespace UniversityManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentRepository.GetAllAsync();

            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Department department)
        {
            await _departmentRepository.AddAsync(department);

            return CreatedAtAction(
                nameof(GetById),
                new { id = department.Id },
                department
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Department department)
        {
            var existingDepartment =
                await _departmentRepository.GetByIdAsync(id);

            if (existingDepartment == null)
            {
                return NotFound();
            }

            department.Id = id;

            await _departmentRepository.UpdateAsync(department);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var department =
                await _departmentRepository.GetByIdAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            await _departmentRepository.DeleteAsync(department);

            return NoContent();
        }
    }
}