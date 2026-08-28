namespace UniversityManagementApi.DTOs.StudentCourses
{
    public class StudentCourseResponseDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;

        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;

        public double Grade { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
