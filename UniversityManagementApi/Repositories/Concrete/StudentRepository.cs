using Microsoft.EntityFrameworkCore;
using UniversityManagementApi.Data;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;

namespace UniversityManagementApi.Repositories.Concrete
{
    public class StudentRepository
        : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<List<Student>> GetStudentsByCourseAsync(int courseId)
        {
            return await _context.Students
                .Where(s => s.StudentCourses
                    .Any(sc => sc.CourseId == courseId))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<StudentCourse>> GetStudentCoursesAsync(int studentId)
        {
            return await _context.StudentCourses
                .Where(sc => sc.StudentId == studentId)
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<double?> GetStudentAverageAsync(int studentId)
        {
            var grades = _context.StudentCourses
                .Where(sc => sc.StudentId == studentId);

            if (!await grades.AnyAsync())
            {
                return null;
            }

            return await grades.AverageAsync(sc => sc.Grade);
        }

        public async Task<List<Student>> GetTopStudentsAsync(int count)
        {
            return await _context.Students
                .Where(s => s.StudentCourses.Any())
                .OrderByDescending(s =>
                    s.StudentCourses.Average(sc => sc.Grade))
                .Take(count)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Student>> SearchStudentsAsync(string name)
        {
            return await _context.Students
                .Where(s =>
                    s.FirstName.Contains(name) ||
                    s.LastName.Contains(name))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Student>> GetStudentsByStudentNumberAsync(string prefix)
        {
            return await _context.Students
                .Where(s => s.StudentNumber.ToString().StartsWith(prefix))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Student>> GetStudentsPagedAsync(int skip, int take)
        {
            return await _context.Students
                .OrderBy(s => s.Id)
                .Skip(skip)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Student>> GetStudentsOrderedByNameAsync()
        {
            return await _context.Students
                .OrderBy(s => s.FirstName)
                .ThenBy(s => s.LastName)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Student>> GetFirstStudentsAsync(int count)
        {
            return await _context.Students
                .OrderBy(s => s.Id)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Student>> GetStudentsByMinGradeAsync(double grade)
        {
            return await _context.Students
                .Where(s => s.StudentCourses
                    .Any(sc => sc.Grade >= grade))
                .AsNoTracking()
                .ToListAsync();
        }
    }

}
