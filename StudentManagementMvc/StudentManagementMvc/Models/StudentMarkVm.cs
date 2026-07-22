namespace StudentManagementMvc.Models
{
    public class StudentMarkVm
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public List<StudentSubjectVm> Subjects { get; set; } = new();
    }
}
