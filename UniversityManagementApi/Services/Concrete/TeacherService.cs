using UniversityManagementApi.DTOs.Teachers;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;
using UniversityManagementApi.Services.Interfaces;

namespace UniversityManagementApi.Services.Concrete
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<List<TeacherResponseDto>> GetAllAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();

            return teachers.Select(teacher => new TeacherResponseDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                EmployeeNumber = teacher.EmployeeNumber,
                DepartmentId = teacher.DepartmentId,
                DepartmentName = teacher.Department != null
                    ? teacher.Department.Name
                    : string.Empty
            }).ToList();
        }

        public async Task<TeacherResponseDto?> GetByIdAsync(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);

            if (teacher == null)
            {
                return null;
            }

            return new TeacherResponseDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                EmployeeNumber = teacher.EmployeeNumber,
                DepartmentId = teacher.DepartmentId,
                DepartmentName = teacher.Department != null
                    ? teacher.Department.Name
                    : string.Empty
            };
        }

        public async Task<TeacherResponseDto> AddAsync(TeacherCreateDto dto)
        {
            var teacher = new Teacher
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                EmployeeNumber = dto.EmployeeNumber,
                DepartmentId = dto.DepartmentId
            };

            await _teacherRepository.AddAsync(teacher);

            return new TeacherResponseDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                EmployeeNumber = teacher.EmployeeNumber,
                DepartmentId = teacher.DepartmentId
            };
        }

        public async Task<bool> UpdateAsync(
            int id,
            TeacherUpdateDto dto)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);

            if (teacher == null)
            {
                return false;
            }

            teacher.FirstName = dto.FirstName;
            teacher.LastName = dto.LastName;
            teacher.Email = dto.Email;
            teacher.EmployeeNumber = dto.EmployeeNumber;
            teacher.DepartmentId = dto.DepartmentId;

            await _teacherRepository.UpdateAsync(teacher);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);

            if (teacher == null)
            {
                return false;
            }

            await _teacherRepository.DeleteAsync(teacher);

            return true;
        }
        public async Task<List<TeacherResponseDto>> GetTeachersByDepartmentAsync(int departmentId)
        {
            var teachers =
                await _teacherRepository.GetTeachersByDepartmentAsync(departmentId);

            return teachers.Select(teacher => new TeacherResponseDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                DepartmentId = teacher.DepartmentId,
                DepartmentName = teacher.Department != null
                    ? teacher.Department.Name
                    : string.Empty
            }).ToList();
        }
        public async Task<List<TeacherResponseDto>> SearchTeachersAsync(string name)
        {
            var teachers =
                await _teacherRepository.SearchTeachersAsync(name);

            return teachers.Select(teacher => new TeacherResponseDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                DepartmentId = teacher.DepartmentId,
                DepartmentName = teacher.Department != null
                    ? teacher.Department.Name
                    : string.Empty
            }).ToList();
        }
    }
}