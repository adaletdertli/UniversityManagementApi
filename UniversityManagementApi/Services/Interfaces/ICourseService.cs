using UniversityManagementApi.DTOs.Courses;

namespace UniversityManagementApi.Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<CourseResponseDto>> GetAllAsync();

        Task<CourseResponseDto?> GetByIdAsync(int id);

        Task<CourseResponseDto> AddAsync(CourseCreateDto dto);

        Task<bool> UpdateAsync(int id, CourseUpdateDto dto);

        Task<bool> DeleteAsync(int id);
        Task<List<CourseResponseDto>> GetCoursesByTeacherAsync(int teacherId);

        Task<List<CourseResponseDto>> GetMostPopularCoursesAsync(int count);

        Task<List<CourseResponseDto>> GetCoursesByCreditAsync(int credit);

        Task<List<CourseResponseDto>> GetCoursesOrderedByCreditAsync();

        Task<List<CourseResponseDto>> GetCoursesWithoutStudentsAsync();
    }
}