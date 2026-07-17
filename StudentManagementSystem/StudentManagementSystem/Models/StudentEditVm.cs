namespace StudentManagementSystem.Models
{
    public class StudentEditVm
    {
        public int Id { get; set; }

        public string StudentName { get; set; } = "";

        public string Department { get; set; } = "";

        public double Mark { get; set; }
    }
}
