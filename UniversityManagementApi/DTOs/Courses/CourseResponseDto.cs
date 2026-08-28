namespace UniversityManagementApi.DTOs.Courses
{
    public class CourseResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int Credit { get; set; }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; } = string.Empty;
    }
}
