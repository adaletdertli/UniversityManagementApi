using Microsoft.EntityFrameworkCore;
using UniversityManagementApi.Data;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;

namespace UniversityManagementApi.Repositories.Concrete
{
    public class DepartmentRepository
        : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context)
            : base(context)
        {
        }

        public override async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments
                .Include(d => d.Teachers)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Department?> GetByIdAsync(int id)
        {
            return await _context.Departments
                .Include(d => d.Teachers)
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Department>> GetDepartmentsOrderedByTeacherCountAsync()
        {
            return await _context.Departments
                .OrderByDescending(d => d.Teachers.Count())
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Department>> GetDepartmentsWithoutTeachersAsync()
        {
            return await _context.Departments
                .Where(d => !d.Teachers.Any())
                .AsNoTracking()
                .ToListAsync();
        }
    }
}