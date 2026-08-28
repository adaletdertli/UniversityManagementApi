using Microsoft.EntityFrameworkCore;
using UniversityManagementApi.Data;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;

namespace UniversityManagementApi.Repositories.Concrete
{
    public class TeacherRepository
        : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context)
            : base(context)
        {
        }

        public override async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.Teachers
                .Include(t => t.Department)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Teacher?> GetByIdAsync(int id)
        {
            return await _context.Teachers
                .Include(t => t.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Teacher>> GetTeachersByDepartmentAsync(int departmentId)
        {
            return await _context.Teachers
                .Where(t => t.DepartmentId == departmentId)
                .Include(t => t.Department)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<List<Teacher>> SearchTeachersAsync(string name)
        {
            return await _context.Teachers
                .Where(t =>
                    t.FirstName.Contains(name) ||
                    t.LastName.Contains(name))
                .Include(t => t.Department)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}