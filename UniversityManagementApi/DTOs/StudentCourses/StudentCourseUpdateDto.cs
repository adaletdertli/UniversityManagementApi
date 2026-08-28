using System.ComponentModel.DataAnnotations;

namespace UniversityManagementApi.DTOs.StudentCourses
{
    public class StudentCourseUpdateDto
    {
        public DateTime EnrollmentDate { get; set; }


        [Range(0, 100)]
        public double Grade { get; set; }
    }
}
