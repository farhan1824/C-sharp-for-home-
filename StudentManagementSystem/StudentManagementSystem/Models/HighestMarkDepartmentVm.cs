using StudentManagementSystem.Entities;

namespace StudentManagementSystem.Models
{
    public class HighestMarkDepartmentVm
    {
        public string Department { get; set; }

        public List<string> Departments { get; set; }

        public Student? TopStudent { get; set; }
    }
}
