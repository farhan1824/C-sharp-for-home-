namespace StudentManagementSystem.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public double Mark { get; set; }

        public string Grade { get; set; } = string.Empty;

        public bool IsPassed { get; set; }
    }
}
