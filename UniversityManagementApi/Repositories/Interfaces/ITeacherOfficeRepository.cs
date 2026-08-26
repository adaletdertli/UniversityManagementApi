using UniversityManagementApi.Entities;

namespace UniversityManagementApi.Repositories.Interfaces
{
    public interface ITeacherOfficeRepository
    {
        Task<List<TeacherOffice>> GetAllAsync();
        Task<TeacherOffice?> GetByIdAsync(int id);
        Task AddAsync(TeacherOffice teacherOffice);
        Task UpdateAsync(TeacherOffice teacherOffice);
        Task DeleteAsync(TeacherOffice teacherOffice);
    }
}
