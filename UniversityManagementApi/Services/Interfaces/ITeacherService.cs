using UniversityManagementApi.DTOs.Teachers;

namespace UniversityManagementApi.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<List<TeacherResponseDto>> GetAllAsync();

        Task<TeacherResponseDto?> GetByIdAsync(int id);

        Task<TeacherResponseDto> AddAsync(TeacherCreateDto dto);

        Task<bool> UpdateAsync(int id, TeacherUpdateDto dto);

        Task<bool> DeleteAsync(int id);

        Task<List<TeacherResponseDto>> GetTeachersByDepartmentAsync(int departmentId);
        Task<List<TeacherResponseDto>> SearchTeachersAsync(string name);
    }
}