namespace UniversityManagementApi.DTOs.Departments
{
    public class DepartmentResponseDto
    {
       
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;

            public int TeacherCount { get; set; }
        }
    }

