using System.ComponentModel.DataAnnotations;

namespace UniversityManagementApi.DTOs.Students
{
    public class StudentCreateDto
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
        public int StudentNumber { get; set; }
    }
}
