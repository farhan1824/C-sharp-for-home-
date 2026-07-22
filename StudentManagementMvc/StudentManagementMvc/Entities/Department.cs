namespace StudentManagementMvc.Entities
{
    public class Department
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; }

        public ICollection<Subject> Subjects { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
