using StudentManagementMvc.Entities;

namespace StudentManagementMvc.Models
{
    public class SubjectEditVm
    {
        public int Id { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; } = new();
    }
}
