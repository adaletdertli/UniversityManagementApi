using UniversityManagementApi.Data;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;

namespace UniversityManagementApi.Repositories.Concrete
{
    public class DepartmentRepository   : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context): base(context)
        {
        }
    }
}