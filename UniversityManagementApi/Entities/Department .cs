namespace UniversityManagementApi.Entities
{
    public class Department
    {
       public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

       public string? Description { get; set; }

        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
