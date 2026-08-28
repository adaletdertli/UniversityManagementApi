using System.ComponentModel.DataAnnotations;

namespace UniversityManagementApi.DTOs.TeacherOffices
{
    public class TeacherOfficeUpdateDto
    {
        [Required]
        [MaxLength(20)]
        public int OfficeNumber { get; set; }

        [Range(-2, 5)]
        public int Floor { get; set; }

        [Range(1, int.MaxValue)]
        public int TeacherId { get; set; }
    }
}
