using UniversityManagementApi.DTOs.Departments;

namespace UniversityManagementApi.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentResponseDto>> GetAllAsync();

        Task<DepartmentResponseDto?> GetByIdAsync(int id);

        Task<DepartmentResponseDto> AddAsync(DepartmentCreateDto dto);

        Task<bool> UpdateAsync(int id, DepartmentUpdateDto dto);

        Task<bool> DeleteAsync(int id);

        Task<List<DepartmentResponseDto>> GetDepartmentsOrderedByTeacherCountAsync();

        Task<List<DepartmentResponseDto>> GetDepartmentsWithoutTeachersAsync();
    }
}