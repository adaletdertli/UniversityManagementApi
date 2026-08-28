using Microsoft.EntityFrameworkCore;
using UniversityManagementApi.Data;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;

namespace UniversityManagementApi.Repositories.Concrete
{
    public class CourseRepository
        : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext context)
            : base(context)
        {
        }

        public override async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses
                .Include(c => c.Teacher)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses
                .Include(c => c.Teacher)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Course>> GetCoursesByTeacherAsync(int teacherId)
        {
            return await _context.Courses
                .Where(c => c.TeacherId == teacherId)
                .Include(c => c.Teacher)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Course>> GetMostPopularCoursesAsync(int count)
        {
            return await _context.Courses
                .Include(c => c.Teacher)
                .OrderByDescending(c => c.StudentCourses.Count())
                .Take(count)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Course>> GetCoursesByCreditAsync(int credit)
        {
            return await _context.Courses
                .Where(c => c.Credit == credit)
                .Include(c => c.Teacher)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Course>> GetCoursesOrderedByCreditAsync()
        {
            return await _context.Courses
                .OrderBy(c => c.Credit)
                .Include(c => c.Teacher)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Course>> GetCoursesWithoutStudentsAsync()
        {
            return await _context.Courses
                .Where(c => !c.StudentCourses.Any())
                .Include(c => c.Teacher)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}