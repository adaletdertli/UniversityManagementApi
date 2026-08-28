using System.ComponentModel.DataAnnotations;

namespace UniversityManagementApi.DTOs.StudentCourses
{
    public class StudentCourseCreateDto
    {

        [Range(1, int.MaxValue)]
        public int StudentId { get; set; }

        [Range(1, int.MaxValue)]
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }

        [Range(0, 100)]
        public double Grade { get; set; }
    }
}
