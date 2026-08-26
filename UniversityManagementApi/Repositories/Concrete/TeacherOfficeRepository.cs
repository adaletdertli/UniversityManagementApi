
using Microsoft.EntityFrameworkCore;
using UniversityManagementApi.Data;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;

namespace UniversityManagementApi.Repositories.Concrete
{
    public class TeacherOfficeRepository : ITeacherOfficeRepository
    {
        private readonly AppDbContext _context;

        public TeacherOfficeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TeacherOffice>> GetAllAsync()
        {
            return await _context.TeacherOffices
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TeacherOffice?> GetByIdAsync(int id)
        {
            return await _context.TeacherOffices
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(TeacherOffice teacherOffice)
        {
            await _context.TeacherOffices.AddAsync(teacherOffice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TeacherOffice teacherOffice)
        {
            _context.TeacherOffices.Update(teacherOffice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TeacherOffice teacherOffice)
        {
            _context.TeacherOffices.Remove(teacherOffice);
            await _context.SaveChangesAsync();
        }
    }
}