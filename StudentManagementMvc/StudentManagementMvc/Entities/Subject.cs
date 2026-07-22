namespace StudentManagementMvc.Entities
{
    public class Subject
    {
        public int Id { get; set; }

        public string SubjectName { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
