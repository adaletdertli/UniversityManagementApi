using UniversityManagementApi.Entities;

namespace UniversityManagementApi.Repositories.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<List<Student>> GetStudentsByCourseAsync(int courseId);

        Task<List<StudentCourse>> GetStudentCoursesAsync(int studentId);

        Task<double?> GetStudentAverageAsync(int studentId);

        Task<List<Student>> GetTopStudentsAsync(int count);

    }
}