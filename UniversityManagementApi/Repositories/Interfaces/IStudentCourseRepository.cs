using UniversityManagementApi.Entities;

namespace UniversityManagementApi.Repositories.Interfaces
{
    public interface IStudentCourseRepository
    {
        Task<List<StudentCourse>> GetAllAsync();

        Task<StudentCourse?> GetByIdAsync(
            int studentId,
            int courseId);

        Task AddAsync(StudentCourse studentCourse);

        Task UpdateAsync(StudentCourse studentCourse);

        Task DeleteAsync(StudentCourse studentCourse);

        Task<List<StudentCourse>> GetByMinimumGradeAsync(double grade);

        Task<double?> GetHighestGradeAsync();

        Task<double?> GetLowestGradeAsync();

        Task<int> GetCourseCountByStudentAsync(int studentId);
    }
}