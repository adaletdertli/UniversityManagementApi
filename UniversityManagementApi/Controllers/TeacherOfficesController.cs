using Microsoft.AspNetCore.Mvc;
using UniversityManagementApi.DTOs.TeacherOffices;
using UniversityManagementApi.Services.Interfaces;

namespace UniversityManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherOfficesController : ControllerBase
    {
        private readonly ITeacherOfficeService _teacherOfficeService;

        public TeacherOfficesController(
            ITeacherOfficeService teacherOfficeService)
        {
            _teacherOfficeService = teacherOfficeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var offices = await _teacherOfficeService.GetAllAsync();

            return Ok(offices);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetById(
            [FromQuery] int id)
        {
            var office = await _teacherOfficeService.GetByIdAsync(id);

            if (office == null)
            {
                return NotFound();
            }

            return Ok(office);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TeacherOfficeCreateDto dto)
        {
            var office = await _teacherOfficeService.AddAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = office.Id },
                office
            );
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            [FromQuery] int id,
            TeacherOfficeUpdateDto dto)
        {
            var result =
                await _teacherOfficeService.UpdateAsync(id, dto);

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
            var result =
                await _teacherOfficeService.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}