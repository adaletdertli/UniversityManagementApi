using Microsoft.EntityFrameworkCore;
using UniversityManagementApi.Data;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;

namespace UniversityManagementApi.Repositories.Concrete
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly AppDbContext _context;

        public StudentCourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentCourse>> GetAllAsync()
        {
            return await _context.StudentCourses
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<StudentCourse?> GetByIdAsync(
            int studentId,
            int courseId)
        {
            return await _context.StudentCourses
                .AsNoTracking()
                .FirstOrDefaultAsync(sc =>
                    sc.StudentId == studentId &&
                    sc.CourseId == courseId);
        }

        public async Task AddAsync(StudentCourse studentCourse)
        {
            await _context.StudentCourses
                .AddAsync(studentCourse);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StudentCourse studentCourse)
        {
            _context.StudentCourses.Update(studentCourse);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(StudentCourse studentCourse)
        {
            _context.StudentCourses.Remove(studentCourse);

            await _context.SaveChangesAsync();
        }
    }
}