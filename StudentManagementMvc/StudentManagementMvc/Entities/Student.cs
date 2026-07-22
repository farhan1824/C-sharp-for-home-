namespace StudentManagementMvc.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string StudentName { get; set; }

        public string StudentId { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
