using UniversityManagementApi.Entities;

namespace UniversityManagementApi.Repositories.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<List<Department>> GetDepartmentsOrderedByTeacherCountAsync();

        Task<List<Department>> GetDepartmentsWithoutTeachersAsync();
    }
}