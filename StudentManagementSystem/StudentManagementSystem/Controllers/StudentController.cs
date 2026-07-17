using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Entities;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class StudentController:Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ===========================
        // Display All Student
        // ===========================
        public async Task<IActionResult> Index()
        {
            var Student = await _context.Student.ToListAsync();
            return View(Student);
            //return View(Student);
        }

        // ===========================
        // Add Student
        // ===========================
        public IActionResult Create()
        {
            var model = new StudentAddVm();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentAddVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            Student student = new Student
            {
                StudentName = vm.StudentName,
                Department = vm.Department,
                Mark = vm.Mark,
                Grade = CalculateGrade(vm.Mark),
                IsPassed = vm.Mark >= 40
            };

            _context.Student.Add(student);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ===========================
        // Student Details
        // ===========================
        public async Task<IActionResult> Details(int id)
        {
            var student = await _context.Student.FindAsync(id);

            if (student == null)
                return NotFound();

            StudentDetailsVm vm = new StudentDetailsVm
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Department = student.Department,
                Mark = student.Mark,
                Grade = student.Grade,
                IsPassed = student.IsPassed
            };

            return View(vm);
        }

        // ===========================
        // Edit Student
        // ===========================
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Student.FindAsync(id);

            if (student == null)
                return NotFound();

            StudentEditVm vm = new StudentEditVm
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Department = student.Department,
                Mark = student.Mark
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentEditVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var student = await _context.Student.FindAsync(vm.Id);

            if (student == null)
                return NotFound();

            student.StudentName = vm.StudentName;
            student.Department = vm.Department;
            student.Mark = vm.Mark;
            student.Grade = CalculateGrade(vm.Mark);
            student.IsPassed = vm.Mark >= 40;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ===========================
        // Delete Student
        // ===========================
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Student.FindAsync(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);

            if (student != null)
            {
                _context.Student.Remove(student);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // ===========================
        // Search By ID
        // ===========================
        public async Task<IActionResult> SearchById(int id)
        {
            var student = await _context.Student
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
                return View("Index", new List<Student>());

            return View("Index", new List<Student> { student });
        }

        // ===========================
        // Search By Name
        // ===========================
        public async Task<IActionResult> SearchByName(string name)
        {
            var Student = await _context.Student
                .Where(s => s.StudentName.Contains(name))
                .ToListAsync();

            return View("Index", Student);
        }

        // ===========================
        // Passed Student
        // ===========================
        public async Task<IActionResult> PassedStudents()
        {
            var Student = await _context.Student
                .Where(s => s.IsPassed)
                .ToListAsync();

            return View(Student);
        }

        // ===========================
        // Student By Grade
        // ===========================
        public async Task<IActionResult> GradeWise(string grade)
        {
            var Student = await _context.Student
                .Where(s => s.Grade == grade)
                .ToListAsync();

            return View(Student);
        }

        // ===========================
        // Student Above Average
        // ===========================
        public async Task<IActionResult> AboveAverage()
        {
            var average = await _context.Student.AverageAsync(s => s.Mark);

            var Student = await _context.Student
                .Where(s => s.Mark > average)
                .ToListAsync();

            ViewBag.Average = average;

            return View(Student);
        }

        // ===========================
        // Sort Student By Marks
        // ===========================
        public async Task<IActionResult> SortByMarks()
        {
            var Student = await _context.Student
                .OrderByDescending(s => s.Mark)
                .ToListAsync();

            return View(Student);
        }
        // ===========================
        // Sort Student By Department
        // ===========================
        public async Task<IActionResult> SortByDepartment()
        {
            var students = await _context.Student
                .OrderBy(s => s.Department)
                .ThenByDescending(s => s.Mark)
                .ToListAsync();

            return View(students);
        }
        // ===========================
        // Highest Mark In Department
        // ===========================
        public async Task<IActionResult> HighestMarkDepartment()
        {
            var students = await _context.Student.ToListAsync();

            HighestMarkDepartmentVm vm = new HighestMarkDepartmentVm
            {
                Departments = new List<string>()
            };


            foreach (var student in students)
            {
                if (!vm.Departments.Contains(student.Department))
                {
                    vm.Departments.Add(student.Department);
                }
            }


            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HighestMarkDepartment(HighestMarkDepartmentVm vm)
        {
            var students = await _context.Student.ToListAsync();


            // Reload departments for dropdown
            vm.Departments = new List<string>();

            foreach (var student in students)
            {
                if (!vm.Departments.Contains(student.Department))
                {
                    vm.Departments.Add(student.Department);
                }
            }


            Student highestStudent = null;


            foreach (var student in students)
            {
                if (student.Department == vm.Department)
                {
                    if (highestStudent == null || student.Mark > highestStudent.Mark)
                    {
                        highestStudent = student;
                    }
                }
            }


            vm.TopStudent = highestStudent;


            return View(vm);
        }
        // ===========================
        // Top Performer
        // ===========================
        public async Task<IActionResult> TopPerformer()
        {
            var student = await _context.Student
                .OrderByDescending(s => s.Mark)
                .FirstOrDefaultAsync();

            return View(student);
        }

        // ===========================
        // Statistics
        // ===========================
        public async Task<IActionResult> Statistics()
        {
            var vm = new StudentStatisticsVm();

            vm.TotalStudents = await _context.Student.CountAsync();

            vm.PassedStudents = await _context.Student.CountAsync(s => s.IsPassed);

            vm.FailedStudents = await _context.Student.CountAsync(s => !s.IsPassed);

            vm.HighestMark = await _context.Student.MaxAsync(s => s.Mark);

            vm.LowestMark = await _context.Student.MinAsync(s => s.Mark);

            vm.AverageMark = await _context.Student.AverageAsync(s => s.Mark);
            var highestStudent = await _context.Student
            .OrderByDescending(s => s.Mark)
            .FirstOrDefaultAsync();
            if (highestStudent != null)
            {
                vm.HighestMarkDepartment = highestStudent.Department;
            }
            return View(vm);
        }

        // ===========================
        // Grade Calculation
        // ===========================
        private string CalculateGrade(double mark)
        {
            if (mark >= 80)
                return "A+";
            if (mark >= 70)
                return "A";
            if (mark >= 60)
                return "A-";
            if (mark >= 50)
                return "B";
            if (mark >= 40)
                return "C";

            return "F";
        }
    }
}
