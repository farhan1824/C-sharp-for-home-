using StudentManagementMvc.Entities;

namespace StudentManagementMvc.Models
{
    public class StudentEditVm
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; } = new();
    }
}
