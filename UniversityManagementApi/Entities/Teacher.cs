namespace UniversityManagementApi.Entities
{
    public class Teacher
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? Email { get; set; }

        public int EmployeeNumber { get; set; }

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();

        public TeacherOffice? TeacherOffice { get; set; }

    }
}
