using UniversityManagementApi.DTOs.TeacherOffices;

namespace UniversityManagementApi.Services.Interfaces
{
    public interface ITeacherOfficeService
    {
        Task<List<TeacherOfficeResponseDto>> GetAllAsync();

        Task<TeacherOfficeResponseDto?> GetByIdAsync(int id);

        Task<TeacherOfficeResponseDto> AddAsync(TeacherOfficeCreateDto dto);

        Task<bool> UpdateAsync(int id, TeacherOfficeUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}