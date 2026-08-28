using UniversityManagementApi.DTOs.StudentCourses;
using UniversityManagementApi.DTOs.Students;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;
using UniversityManagementApi.Services.Interfaces;

namespace UniversityManagementApi.Services.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentResponseDto>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();

            return students.Select(student => new StudentResponseDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                StudentNumber = student.StudentNumber
            }).ToList();
        }

        public async Task<StudentResponseDto?> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
            {
                return null;
            }

            return new StudentResponseDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                StudentNumber = student.StudentNumber
            };
        }

        public async Task<StudentResponseDto> AddAsync(StudentCreateDto dto)
        {
            var student = new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                StudentNumber = dto.StudentNumber
            };

            await _studentRepository.AddAsync(student);

            return new StudentResponseDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                StudentNumber = student.StudentNumber
            };
        }

        public async Task<bool> UpdateAsync(
            int id,
            StudentUpdateDto dto)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
            {
                return false;
            }

            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;
            student.Email = dto.Email;
            student.StudentNumber = dto.StudentNumber;

            await _studentRepository.UpdateAsync(student);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
            {
                return false;
            }

            await _studentRepository.DeleteAsync(student);

            return true;
        }
        public async Task<List<StudentResponseDto>> GetStudentsByCourseAsync(int courseId)
        {
            var students =
                await _studentRepository.GetStudentsByCourseAsync(courseId);

            return students.Select(student => new StudentResponseDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                StudentNumber = student.StudentNumber
            }).ToList();
        }

        public async Task<List<StudentCourseResponseDto>> GetStudentCoursesAsync(int studentId)
        {
            var studentCourses =
                await _studentRepository.GetStudentCoursesAsync(studentId);

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

        public async Task<double?> GetStudentAverageAsync(int studentId)
        {
            return await _studentRepository.GetStudentAverageAsync(studentId);
        }

        public async Task<List<StudentResponseDto>> GetTopStudentsAsync(int count)
        {
            var students =
                await _studentRepository.GetTopStudentsAsync(count);

            return students.Select(student => new StudentResponseDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                StudentNumber = student.StudentNumber
            }).ToList();
        }
        public async Task<List<StudentResponseDto>> SearchStudentsAsync(string name)
        {
            var students =
                await _studentRepository.SearchStudentsAsync(name);

            return students.Select(student => new StudentResponseDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                StudentNumber = student.StudentNumber
            }).ToList();
        }

        public async Task<List<StudentResponseDto>> GetStudentsByStudentNumberAsync(string prefix)
        {
            var students =
                await _studentRepository.GetStudentsByStudentNumberAsync(prefix);

            return students.Select(student => new StudentResponseDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                StudentNumber = student.StudentNumber
            }).ToList();
        }

        public async Task<List<StudentResponseDto>> GetStudentsPagedAsync(int skip, int take)
        {
            var students =
                await _studentRepository.GetStudentsPagedAsync(skip, take);

            return students.Select(student => new StudentResponseDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                StudentNumber = student.StudentNumber
            }).ToList();
        }
        public async Task<List<StudentResponseDto>> GetStudentsOrderedByNameAsync()
        {
            var students =
                await _studentRepository.GetStudentsOrderedByNameAsync();

            return students.Select(student => new StudentResponseDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                StudentNumber = student.StudentNumber
            }).ToList();
        }

        public async Task<List<StudentResponseDto>> GetFirstStudentsAsync(int count)
        {
            var students =
                await _studentRepository.GetFirstStudentsAsync(count);

            return students.Select(student => new StudentResponseDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                StudentNumber = student.StudentNumber
            }).ToList();
        }

        public async Task<List<StudentResponseDto>> GetStudentsByMinGradeAsync(double grade)
        {
            var students =
                await _studentRepository.GetStudentsByMinGradeAsync(grade);

            return students.Select(student => new StudentResponseDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                StudentNumber = student.StudentNumber
            }).ToList();
        }

    }
}