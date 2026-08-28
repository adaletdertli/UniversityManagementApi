using UniversityManagementApi.DTOs.StudentCourses;

namespace UniversityManagementApi.Services.Interfaces
{
    public interface IStudentCourseService
    {
        Task<List<StudentCourseResponseDto>> GetAllAsync();

        Task<StudentCourseResponseDto?> GetByIdAsync(
            int studentId,
            int courseId);

        Task<StudentCourseResponseDto> AddAsync(
            StudentCourseCreateDto dto);

        Task<bool> UpdateAsync(
            int studentId,
            int courseId,
            StudentCourseUpdateDto dto);

        Task<bool> DeleteAsync(
            int studentId,
            int courseId);

        Task<List<StudentCourseResponseDto>> GetByMinimumGradeAsync(double grade);

        Task<double?> GetHighestGradeAsync();

        Task<double?> GetLowestGradeAsync();

        Task<int> GetCourseCountByStudentAsync(int studentId);
    }
}