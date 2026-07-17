namespace StudentManagementSystem.Models
{
    public class StudentStatisticsVm
    {
        public int TotalStudents { get; set; }

        public int PassedStudents { get; set; }

        public int FailedStudents { get; set; }

        public double HighestMark { get; set; }

        public double LowestMark { get; set; }

        public double AverageMark { get; set; }

        public string HighestMarkDepartment { get; set; }
    }
}
