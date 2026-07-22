using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentManagementMvc.Entities;

namespace StudentManagementMvc.Models
{
    public class StudentAddVm
    {
        public string StudentName { get; set; }

        public string StudentId { get; set; }

        public int DepartmentId { get; set; }
        [ValidateNever]
        public List<Department> Departments { get; set; }
    }
}
