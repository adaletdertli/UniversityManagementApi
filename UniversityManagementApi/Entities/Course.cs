namespace UniversityManagementApi.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int Credit { get; set; }
        public int TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();



    }
}
