using UniversityManagementApi.DTOs.Departments;
using UniversityManagementApi.Entities;
using UniversityManagementApi.Repositories.Interfaces;
using UniversityManagementApi.Services.Interfaces;

namespace UniversityManagementApi.Services.Concrete
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<List<DepartmentResponseDto>> GetAllAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();

            return departments.Select(department => new DepartmentResponseDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                TeacherCount = department.Teachers.Count
            }).ToList();
        }

        public async Task<DepartmentResponseDto?> GetByIdAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);

            if (department == null)
            {
                return null;
            }

            return new DepartmentResponseDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                TeacherCount = department.Teachers.Count
            };
        }

        public async Task<DepartmentResponseDto> AddAsync(
            DepartmentCreateDto dto)
        {
            var department = new Department
            {
                Name = dto.Name,
                Description = dto.Description
            };

            await _departmentRepository.AddAsync(department);

            return new DepartmentResponseDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                TeacherCount = 0
            };
        }

        public async Task<bool> UpdateAsync(
            int id,
            DepartmentUpdateDto dto)
        {
            var department = await _departmentRepository.GetByIdAsync(id);

            if (department == null)
            {
                return false;
            }

            department.Name = dto.Name;
            department.Description = dto.Description;

            await _departmentRepository.UpdateAsync(department);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);

            if (department == null)
            {
                return false;
            }

            await _departmentRepository.DeleteAsync(department);

            return true;
        }

        public async Task<List<DepartmentResponseDto>> GetDepartmentsOrderedByTeacherCountAsync()
        {
            var departments =
                await _departmentRepository.GetDepartmentsOrderedByTeacherCountAsync();

            return departments.Select(department => new DepartmentResponseDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                TeacherCount = department.Teachers.Count
            }).ToList();
        }

        public async Task<List<DepartmentResponseDto>> GetDepartmentsWithoutTeachersAsync()
        {
            var departments =
                await _departmentRepository.GetDepartmentsWithoutTeachersAsync();

            return departments.Select(department => new DepartmentResponseDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                TeacherCount = 0
            }).ToList();
        }
    }
}