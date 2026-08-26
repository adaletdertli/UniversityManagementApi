using Microsoft.AspNetCore.Mvc;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;

namespace UniversityManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherOfficesController : ControllerBase
    {
        private readonly ITeacherOfficeRepository _teacherOfficeRepository;

        public TeacherOfficesController(
            ITeacherOfficeRepository teacherOfficeRepository)
        {
            _teacherOfficeRepository = teacherOfficeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teacherOffices =
                await _teacherOfficeRepository.GetAllAsync();

            return Ok(teacherOffices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacherOffice =
                await _teacherOfficeRepository.GetByIdAsync(id);

            if (teacherOffice == null)
            {
                return NotFound();
            }

            return Ok(teacherOffice);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TeacherOffice teacherOffice)
        {
            await _teacherOfficeRepository.AddAsync(teacherOffice);

            return CreatedAtAction(
                nameof(GetById),
                new { id = teacherOffice.Id },
                teacherOffice
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            TeacherOffice teacherOffice)
        {
            var existingTeacherOffice =
                await _teacherOfficeRepository.GetByIdAsync(id);

            if (existingTeacherOffice == null)
            {
                return NotFound();
            }

            teacherOffice.Id = id;

            await _teacherOfficeRepository.UpdateAsync(teacherOffice);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teacherOffice =
                await _teacherOfficeRepository.GetByIdAsync(id);

            if (teacherOffice == null)
            {
                return NotFound();
            }

            await _teacherOfficeRepository.DeleteAsync(teacherOffice);

            return NoContent();
        }
    }
}