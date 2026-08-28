namespace UniversityManagementApi.DTOs.Students
{
    public class StudentResponseDto
    {

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int StudentNumber { get; set; }
    }
}
