using System.ComponentModel.DataAnnotations;

namespace UniversityManagementApi.DTOs.Courses
{
    public class CourseUpdateDto
    {


        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Code { get; set; } = string.Empty;

        [Range(1, 10)]
        public int Credit { get; set; }

        [Range(1, int.MaxValue)]
        public int TeacherId { get; set; }
    }
}
