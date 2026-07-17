namespace StudentManagementSystem.Models
{
    public class StudentDetailsVm
    {
        public int Id { get; set; }

        public string StudentName { get; set; } = "";

        public string Department { get; set; } = "";

        public double Mark { get; set; }

        public string Grade { get; set; } = "";

        public bool IsPassed { get; set; }
    }
}
