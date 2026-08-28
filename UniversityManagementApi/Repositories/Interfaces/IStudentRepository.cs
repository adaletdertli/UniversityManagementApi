
using UniversityManagementApi.Entities;

namespace UniversityManagementApi.Repositories.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<List<Student>> GetStudentsByCourseAsync(int courseId);

        Task<List<StudentCourse>> GetStudentCoursesAsync(int studentId);

        Task<double?> GetStudentAverageAsync(int studentId);

        Task<List<Student>> GetTopStudentsAsync(int count);

        Task<List<Student>> SearchStudentsAsync(string name);

        Task<List<Student>> GetStudentsByStudentNumberAsync(string prefix);

        Task<List<Student>> GetStudentsPagedAsync(int skip, int take);
        Task<List<Student>> GetStudentsOrderedByNameAsync();

        Task<List<Student>> GetFirstStudentsAsync(int count);

        Task<List<Student>> GetStudentsByMinGradeAsync(double grade);

    }
}