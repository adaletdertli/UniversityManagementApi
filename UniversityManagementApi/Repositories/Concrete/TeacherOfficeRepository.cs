using UniversityManagementApi.Data;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;

namespace UniversityManagementApi.Repositories.Concrete
{
    public class TeacherOfficeRepository : GenericRepository<TeacherOffice>, ITeacherOfficeRepository
    {
        public TeacherOfficeRepository(AppDbContext context)  : base(context)
        {
        }
    }
}