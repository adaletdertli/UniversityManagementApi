using UniversityManagementApi.DTOs.StudentCourses;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;
using UniversityManagementApi.Services.Interfaces;

namespace UniversityManagementApi.Services.Concrete
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IStudentCourseRepository _studentCourseRepository;

        public StudentCourseService(
            IStudentCourseRepository studentCourseRepository)
        {
            _studentCourseRepository = studentCourseRepository;
        }

        public async Task<List<StudentCourseResponseDto>> GetAllAsync()
        {
            var studentCourses =
                await _studentCourseRepository.GetAllAsync();

            return studentCourses.Select(sc => new StudentCourseResponseDto
            {
                StudentId = sc.StudentId,
                StudentName = sc.Student != null
                    ? sc.Student.FirstName + " " + sc.Student.LastName
                    : string.Empty,

                CourseId = sc.CourseId,
                CourseName = sc.Course != null
                    ? sc.Course.Name
                    : string.Empty,

                CourseCode = sc.Course != null
                    ? sc.Course.Code
                    : string.Empty,

                Grade = sc.Grade,
                EnrollmentDate = sc.EnrollmentDate
            }).ToList();
        }

        public async Task<StudentCourseResponseDto?> GetByIdAsync(
            int studentId,
            int courseId)
        {
            var studentCourse =
                await _studentCourseRepository.GetByIdAsync(
                    studentId,
                    courseId);

            if (studentCourse == null)
            {
                return null;
            }

            return new StudentCourseResponseDto
            {
                StudentId = studentCourse.StudentId,
                StudentName = studentCourse.Student != null
                    ? studentCourse.Student.FirstName + " " +
                      studentCourse.Student.LastName
                    : string.Empty,

                CourseId = studentCourse.CourseId,
                CourseName = studentCourse.Course != null
                    ? studentCourse.Course.Name
                    : string.Empty,

                CourseCode = studentCourse.Course != null
                    ? studentCourse.Course.Code
                    : string.Empty,

                Grade = studentCourse.Grade,
                EnrollmentDate = studentCourse.EnrollmentDate
            };
        }

        public async Task<StudentCourseResponseDto> AddAsync(
    StudentCourseCreateDto dto)
        {
            var studentCourse = new StudentCourse
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
                EnrollmentDate = dto.EnrollmentDate,
                Grade = dto.Grade
            };

            await _studentCourseRepository.AddAsync(studentCourse);

            var createdStudentCourse =
                await _studentCourseRepository.GetByIdAsync(
                    studentCourse.StudentId,
                    studentCourse.CourseId);

            return new StudentCourseResponseDto
            {
                StudentId = createdStudentCourse!.StudentId,

                StudentName = createdStudentCourse.Student != null
                    ? createdStudentCourse.Student.FirstName + " " +
                      createdStudentCourse.Student.LastName
                    : string.Empty,

                CourseId = createdStudentCourse.CourseId,

                CourseName = createdStudentCourse.Course != null
                    ? createdStudentCourse.Course.Name
                    : string.Empty,

                CourseCode = createdStudentCourse.Course != null
                    ? createdStudentCourse.Course.Code
                    : string.Empty,

                Grade = createdStudentCourse.Grade,
                EnrollmentDate = createdStudentCourse.EnrollmentDate
            };
        }

        public async Task<bool> UpdateAsync(
            int studentId,
            int courseId,
            StudentCourseUpdateDto dto)
        {
            var studentCourse =
                await _studentCourseRepository.GetByIdAsync(
                    studentId,
                    courseId);

            if (studentCourse == null)
            {
                return false;
            }

            studentCourse.EnrollmentDate = dto.EnrollmentDate;
            studentCourse.Grade = dto.Grade;

            await _studentCourseRepository.UpdateAsync(studentCourse);

            return true;
        }

        public async Task<bool> DeleteAsync(
            int studentId,
            int courseId)
        {
            var studentCourse =
                await _studentCourseRepository.GetByIdAsync(
                    studentId,
                    courseId);

            if (studentCourse == null)
            {
                return false;
            }

            await _studentCourseRepository.DeleteAsync(studentCourse);

            return true;
        }
        public async Task<List<StudentCourseResponseDto>> GetByMinimumGradeAsync(double grade)
        {
            var studentCourses =
                await _studentCourseRepository.GetByMinimumGradeAsync(grade);

            return studentCourses.Select(sc => new StudentCourseResponseDto
            {
                StudentId = sc.StudentId,
                StudentName = sc.Student != null
                    ? sc.Student.FirstName + " " + sc.Student.LastName
                    : string.Empty,

                CourseId = sc.CourseId,
                CourseName = sc.Course != null
                    ? sc.Course.Name
                    : string.Empty,

                CourseCode = sc.Course != null
                    ? sc.Course.Code
                    : string.Empty,

                Grade = sc.Grade,
                EnrollmentDate = sc.EnrollmentDate
            }).ToList();
        }

        public async Task<double?> GetHighestGradeAsync()
        {
            return await _studentCourseRepository.GetHighestGradeAsync();
        }

        public async Task<double?> GetLowestGradeAsync()
        {
            return await _studentCourseRepository.GetLowestGradeAsync();
        }

        public async Task<int> GetCourseCountByStudentAsync(int studentId)
        {
            return await _studentCourseRepository.GetCourseCountByStudentAsync(studentId);
        }
    }
}