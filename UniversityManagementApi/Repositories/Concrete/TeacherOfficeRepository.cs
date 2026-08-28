using Microsoft.EntityFrameworkCore;
using UniversityManagementApi.Data;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;

namespace UniversityManagementApi.Repositories.Concrete
{
    public class TeacherOfficeRepository
        : GenericRepository<TeacherOffice>, ITeacherOfficeRepository
    {
        public TeacherOfficeRepository(AppDbContext context)
            : base(context)
        {
        }

        public override async Task<List<TeacherOffice>> GetAllAsync()
        {
            return await _context.TeacherOffices
                .Include(to => to.Teacher)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<TeacherOffice?> GetByIdAsync(int id)
        {
            return await _context.TeacherOffices
                .Include(to => to.Teacher)
                .AsNoTracking()
                .FirstOrDefaultAsync(to => to.Id == id);
        }
    }
}