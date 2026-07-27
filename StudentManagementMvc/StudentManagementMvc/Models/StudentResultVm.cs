namespace StudentManagementMvc.Models
{
    public class StudentResultVm
    {
        public string StudentName { get; set; }

        public string StudentId { get; set; }

        public string DepartmentName { get; set; }

        public List<StudentSubjectVm> Subjects { get; set; }

        public double AverageMark { get; set; }

        public double CGPA { get; set; }

        public string Grade { get; set; }

        public bool IsPassed { get; set; }
    }
}
