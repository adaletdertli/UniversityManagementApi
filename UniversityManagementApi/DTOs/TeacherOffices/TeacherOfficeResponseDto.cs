namespace UniversityManagementApi.DTOs.TeacherOffices
{
    public class TeacherOfficeResponseDto
    {
        public int Id { get; set; }
        public int OfficeNumber { get; set; }
        public int Floor { get; set; }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; } = string.Empty;
    }
}
