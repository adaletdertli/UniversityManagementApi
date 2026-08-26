namespace UniversityManagementApi.Entities
{
    public class TeacherOffice
    {
        public int Id { get; set; }
        public int OfficeNumber { get; set; }
        public int Floor { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

    }
}
