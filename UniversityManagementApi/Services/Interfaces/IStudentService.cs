using UniversityManagementApi.DTOs.StudentCourses;
using UniversityManagementApi.DTOs.Students;

namespace UniversityManagementApi.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentResponseDto>> GetAllAsync();

        Task<StudentResponseDto?> GetByIdAsync(int id);

        Task<StudentResponseDto> AddAsync(StudentCreateDto dto);

        Task<bool> UpdateAsync(int id, StudentUpdateDto dto);

        Task<bool> DeleteAsync(int id);

        Task<List<StudentResponseDto>> GetStudentsByCourseAsync(int courseId);

        Task<List<StudentCourseResponseDto>> GetStudentCoursesAsync(int studentId);

        Task<double?> GetStudentAverageAsync(int studentId);

        Task<List<StudentResponseDto>> GetTopStudentsAsync(int count);

        Task<List<StudentResponseDto>> SearchStudentsAsync(string name);

        Task<List<StudentResponseDto>> GetStudentsByStudentNumberAsync(string prefix);

        Task<List<StudentResponseDto>> GetStudentsPagedAsync(int skip, int take);

        Task<List<StudentResponseDto>> GetStudentsOrderedByNameAsync();

        Task<List<StudentResponseDto>> GetFirstStudentsAsync(int count);

        Task<List<StudentResponseDto>> GetStudentsByMinGradeAsync(double grade);

    }
}
