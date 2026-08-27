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
    }
}