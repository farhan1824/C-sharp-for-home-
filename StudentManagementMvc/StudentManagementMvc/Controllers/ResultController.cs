using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementMvc.Data;
using StudentManagementMvc.Models;

namespace StudentManagementMvc.Controllers
{
    public class ResultController : Controller
    {
        private readonly ApplicationDbContext _context;


        public ResultController(ApplicationDbContext context)
        {
            _context = context;
        }


        // Display All Students for Result
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students
                .Include(s => s.Department)
                .ToListAsync();

            return View(students);
        }
        // Display Student Result
        public async Task<IActionResult> StudentResult(int id)
        {
            var student = await _context.Students
                .Include(s => s.Department)
                .Include(s => s.StudentSubjects)
                    .ThenInclude(ss => ss.Subject)
                .FirstOrDefaultAsync(s => s.Id == id);


            if (student == null)
                return NotFound();



            var studentMarks = new StudentMarkVm
            {
                StudentId = student.Id,

                StudentName = student.StudentName,

                Subjects = student.StudentSubjects
                    .Select(ss => new StudentSubjectVm
                    {
                        SubjectId = ss.SubjectId,

                        SubjectName = ss.Subject.SubjectName,

                        Mark = ss.Mark

                    })
                    .ToList()
            };



            double average = student.StudentSubjects.Any()
                ? student.StudentSubjects.Average(x => x.Mark)
                : 0;



            StudentResultVm vm = new()
            {
                StudentName = student.StudentName,

                StudentId = student.StudentId,

                DepartmentName = student.Department.DepartmentName,

                Subjects = new List<StudentMarkVm>
                {
                    studentMarks
                },

                AverageMark = average,

                CGPA = CalculateCGPA(average),

                Grade = CalculateGrade(average),

                IsPassed = student.StudentSubjects
                    .All(x => x.Mark >= 40)
            };


            return View(vm);
        }


        // Display Students By Grade
        public async Task<IActionResult> StudentsByGrade(string grade)
        {
            var students = await _context.Students
                .Include(s => s.StudentSubjects)
                .ToListAsync();



            var result = students
      .Where(s =>
          CalculateGrade(
              s.StudentSubjects.Any()
              ? s.StudentSubjects.Average(x => x.Mark)
              : 0
          ) == grade)
      .ToList();


            return View(result);
        }








        // Sort Students By Average Mark
        public async Task<IActionResult> SortByMark()
        {
            var students = await _context.Students
                .Include(s => s.StudentSubjects)
                .ToListAsync();



            var result = students
                .OrderByDescending(s =>
                    s.StudentSubjects.Average(x => x.Mark))
                .ToList();



            return View(result);
        }








        // Top Performer
        public async Task<IActionResult> TopPerformer()
        {
            var student = await _context.Students
                .Include(s => s.StudentSubjects)
                .OrderByDescending(s =>
                    s.StudentSubjects.Average(x => x.Mark))
                .FirstOrDefaultAsync();



            return View(student);
        }








        // Statistics
        public async Task<IActionResult> Statistics()
        {
            var students = await _context.Students
                .Include(s => s.StudentSubjects)
                .ToListAsync();



            var marks = students
                .SelectMany(s => s.StudentSubjects)
                .Select(ss => ss.Mark)
                .ToList();



            StatisticsVm vm = new()
            {
                TotalStudents = students.Count,

                PassedStudents = students.Count(s =>
                    s.StudentSubjects.All(ss => ss.Mark >= 40)),

                FailedStudents = students.Count(s =>
                    s.StudentSubjects.Any(ss => ss.Mark < 40))
            };



            if (marks.Any())
            {
                vm.HighestMark = marks.Max();

                vm.LowestMark = marks.Min();

                vm.AverageMark = marks.Average();
            }



            return View(vm);
        }










        private double CalculateCGPA(double average)
        {
            if (average >= 80)
                return 4.00;

            if (average >= 75)
                return 3.75;

            if (average >= 70)
                return 3.50;

            if (average >= 65)
                return 3.25;

            if (average >= 60)
                return 3.00;

            if (average >= 55)
                return 2.75;

            if (average >= 50)
                return 2.50;

            if (average >= 45)
                return 2.25;

            if (average >= 40)
                return 2.00;


            return 0;
        }








        private string CalculateGrade(double average)
        {
            if (average >= 80)
                return "A+";

            if (average >= 75)
                return "A";

            if (average >= 70)
                return "A-";

            if (average >= 65)
                return "B+";

            if (average >= 60)
                return "B";

            if (average >= 55)
                return "C+";

            if (average >= 50)
                return "C";

            if (average >= 45)
                return "D";


            return "F";
        }
    }
}