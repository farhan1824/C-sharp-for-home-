using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentManagementMvc.Entities;

namespace StudentManagementMvc.Models
{
    public class StudentVm
    {
        public int Id { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public string StudentId { get; set; } = string.Empty;

        public int DepartmentId { get; set; }

        [ValidateNever]
        public List<Department> Departments { get; set; } = new();
    }
}
