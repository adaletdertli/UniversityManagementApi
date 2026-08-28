using System.ComponentModel.DataAnnotations;

namespace UniversityManagementApi.DTOs.Teachers
{
    public class TeacherCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int EmployeeNumber { get; set; }

        [Range(1, int.MaxValue)]
        public int DepartmentId { get; set; }
    }
}
