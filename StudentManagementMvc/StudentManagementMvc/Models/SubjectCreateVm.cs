using StudentManagementMvc.Entities;

namespace StudentManagementMvc.Models
{
    public class SubjectCreateVm
    {
        public string SubjectName { get; set; } = string.Empty;

        public int DepartmentId { get; set; }

        // For dropdown list
        public List<Department> Departments { get; set; } = new();
    }
}
