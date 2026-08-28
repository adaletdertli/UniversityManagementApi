using UniversityManagementApi.DTOs.Courses;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;
using UniversityManagementApi.Services.Interfaces;

namespace UniversityManagementApi.Services.Concrete
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<CourseResponseDto>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();

            return courses.Select(course => new CourseResponseDto
            {
                Id = course.Id,
                Name = course.Name,
                Code = course.Code,
                Credit = course.Credit,
                TeacherId = course.TeacherId,
                TeacherName = course.Teacher != null
                    ? course.Teacher.FirstName + " " + course.Teacher.LastName
                    : string.Empty
            }).ToList();
        }

        public async Task<CourseResponseDto?> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
            {
                return null;
            }

            return new CourseResponseDto
            {
                Id = course.Id,
                Name = course.Name,
                Code = course.Code,
                Credit = course.Credit,
                TeacherId = course.TeacherId,
                TeacherName = course.Teacher != null
                    ? course.Teacher.FirstName + " " + course.Teacher.LastName
                    : string.Empty
            };
        }

        public async Task<CourseResponseDto> AddAsync(CourseCreateDto dto)
        {
            var course = new Course
            {
                Name = dto.Name,
                Code = dto.Code,
                Credit = dto.Credit,
                TeacherId = dto.TeacherId
            };

            await _courseRepository.AddAsync(course);

            return new CourseResponseDto
            {
                Id = course.Id,
                Name = course.Name,
                Code = course.Code,
                Credit = course.Credit,
                TeacherId = course.TeacherId,
                TeacherName = string.Empty
            };
        }

        public async Task<bool> UpdateAsync(
            int id,
            CourseUpdateDto dto)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
            {
                return false;
            }

            course.Name = dto.Name;
            course.Code = dto.Code;
            course.Credit = dto.Credit;
            course.TeacherId = dto.TeacherId;

            await _courseRepository.UpdateAsync(course);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
            {
                return false;
            }

            await _courseRepository.DeleteAsync(course);

            return true;
        }
        public async Task<List<CourseResponseDto>> GetCoursesByTeacherAsync(int teacherId)
        {
            var courses =
                await _courseRepository.GetCoursesByTeacherAsync(teacherId);

            return courses.Select(course => new CourseResponseDto
            {
                Id = course.Id,
                Name = course.Name,
                Code = course.Code,
                Credit = course.Credit,
                TeacherId = course.TeacherId,
                TeacherName = course.Teacher != null
                    ? course.Teacher.FirstName + " " + course.Teacher.LastName
                    : string.Empty
            }).ToList();
        }

        public async Task<List<CourseResponseDto>> GetMostPopularCoursesAsync(int count)
        {
            var courses =
                await _courseRepository.GetMostPopularCoursesAsync(count);

            return courses.Select(course => new CourseResponseDto
            {
                Id = course.Id,
                Name = course.Name,
                Code = course.Code,
                Credit = course.Credit,
                TeacherId = course.TeacherId,
                TeacherName = course.Teacher != null
                    ? course.Teacher.FirstName + " " + course.Teacher.LastName
                    : string.Empty
            }).ToList();
        }
        public async Task<List<CourseResponseDto>> GetCoursesByCreditAsync(int credit)
        {
            var courses =
                await _courseRepository.GetCoursesByCreditAsync(credit);

            return courses.Select(course => new CourseResponseDto
            {
                Id = course.Id,
                Name = course.Name,
                Code = course.Code,
                Credit = course.Credit,
                TeacherId = course.TeacherId,
                TeacherName = course.Teacher != null
                    ? course.Teacher.FirstName + " " + course.Teacher.LastName
                    : string.Empty
            }).ToList();
        }

        public async Task<List<CourseResponseDto>> GetCoursesOrderedByCreditAsync()
        {
            var courses =
                await _courseRepository.GetCoursesOrderedByCreditAsync();

            return courses.Select(course => new CourseResponseDto
            {
                Id = course.Id,
                Name = course.Name,
                Code = course.Code,
                Credit = course.Credit,
                TeacherId = course.TeacherId,
                TeacherName = course.Teacher != null
                    ? course.Teacher.FirstName + " " + course.Teacher.LastName
                    : string.Empty
            }).ToList();
        }

        public async Task<List<CourseResponseDto>> GetCoursesWithoutStudentsAsync()
        {
            var courses =
                await _courseRepository.GetCoursesWithoutStudentsAsync();

            return courses.Select(course => new CourseResponseDto
            {
                Id = course.Id,
                Name = course.Name,
                Code = course.Code,
                Credit = course.Credit,
                TeacherId = course.TeacherId,
                TeacherName = course.Teacher != null
                    ? course.Teacher.FirstName + " " + course.Teacher.LastName
                    : string.Empty
            }).ToList();
        }
    }
}