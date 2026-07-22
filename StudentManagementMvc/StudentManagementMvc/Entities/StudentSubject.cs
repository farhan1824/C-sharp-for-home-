namespace StudentManagementMvc.Entities
{
    public class StudentSubject
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        public double Mark { get; set; }
    }
}
