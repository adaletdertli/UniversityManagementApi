using UniversityManagementApi.Entities;

namespace UniversityManagementApi.Repositories.Interfaces
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<List<Teacher>> GetTeachersByDepartmentAsync(int departmentId);
        Task<List<Teacher>> SearchTeachersAsync(string name);

    }
}