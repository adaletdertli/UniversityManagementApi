using UniversityManagementApi.DTOs.TeacherOffices;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;
using UniversityManagementApi.Services.Interfaces;

namespace UniversityManagementApi.Services.Concrete
{
    public class TeacherOfficeService : ITeacherOfficeService
    {
        private readonly ITeacherOfficeRepository _teacherOfficeRepository;

        public TeacherOfficeService(
            ITeacherOfficeRepository teacherOfficeRepository)
        {
            _teacherOfficeRepository = teacherOfficeRepository;
        }

        public async Task<List<TeacherOfficeResponseDto>> GetAllAsync()
        {
            var offices = await _teacherOfficeRepository.GetAllAsync();

            return offices.Select(office => new TeacherOfficeResponseDto
            {
                Id = office.Id,
                OfficeNumber = office.OfficeNumber,
                Floor = office.Floor,
                TeacherId = office.TeacherId,
                TeacherName = office.Teacher != null
                    ? office.Teacher.FirstName + " " + office.Teacher.LastName
                    : string.Empty
            }).ToList();
        }

        public async Task<TeacherOfficeResponseDto?> GetByIdAsync(int id)
        {
            var office = await _teacherOfficeRepository.GetByIdAsync(id);

            if (office == null)
            {
                return null;
            }

            return new TeacherOfficeResponseDto
            {
                Id = office.Id,
                OfficeNumber = office.OfficeNumber,
                Floor = office.Floor,
                TeacherId = office.TeacherId,
                TeacherName = office.Teacher != null
                    ? office.Teacher.FirstName + " " + office.Teacher.LastName
                    : string.Empty
            };
        }

        public async Task<TeacherOfficeResponseDto> AddAsync(
            TeacherOfficeCreateDto dto)
        {
            var office = new TeacherOffice
            {
                OfficeNumber = dto.OfficeNumber,
                Floor = dto.Floor,
                TeacherId = dto.TeacherId
            };

            await _teacherOfficeRepository.AddAsync(office);

            return new TeacherOfficeResponseDto
            {
                Id = office.Id,
                OfficeNumber = office.OfficeNumber,
                Floor = office.Floor,
                TeacherId = office.TeacherId
            };
        }

        public async Task<bool> UpdateAsync(
            int id,
            TeacherOfficeUpdateDto dto)
        {
            var office = await _teacherOfficeRepository.GetByIdAsync(id);

            if (office == null)
            {
                return false;
            }

            office.OfficeNumber = dto.OfficeNumber;
            office.Floor = dto.Floor;
            office.TeacherId = dto.TeacherId;

            await _teacherOfficeRepository.UpdateAsync(office);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var office = await _teacherOfficeRepository.GetByIdAsync(id);

            if (office == null)
            {
                return false;
            }

            await _teacherOfficeRepository.DeleteAsync(office);

            return true;
        }
    }
}