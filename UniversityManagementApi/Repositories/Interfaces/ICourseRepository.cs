using UniversityManagementApi.Entities;

namespace UniversityManagementApi.Repositories.Interfaces
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<List<Course>> GetCoursesByTeacherAsync(int teacherId);

        Task<List<Course>> GetMostPopularCoursesAsync(int count);

        Task<List<Course>> GetCoursesByCreditAsync(int credit);

        Task<List<Course>> GetCoursesOrderedByCreditAsync();

        Task<List<Course>> GetCoursesWithoutStudentsAsync();
    }
}