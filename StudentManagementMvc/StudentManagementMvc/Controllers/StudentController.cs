using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementMvc.Data;
using StudentManagementMvc.Entities;
using StudentManagementMvc.Models;

namespace StudentManagementMvc.Controllers
{
    public class StudentController : Controller
    {

        private readonly ApplicationDbContext _context;


        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.Students
                .Include(s => s.Department)
                .ToListAsync();


            return View(students);
        }

        public async Task<IActionResult> Create()
        {
            var model = new StudentVm
            {
                Departments = await _context.Departments.ToListAsync()
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentVm vm)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student
                {
                    StudentName = vm.StudentName,

                    StudentId = vm.StudentId,

                    DepartmentId = vm.DepartmentId
                };


                _context.Students.Add(student);

                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }
        public async Task<IActionResult> AddMarks(int id)
        {

            var student = await _context.Students
                .Include(s => s.Department)
                .Include(s => s.StudentSubjects)
                .FirstOrDefaultAsync(s => s.Id == id);



            if (student == null)
                return NotFound();



            var subjects = await _context.Subjects
                .Where(s => s.DepartmentId == student.DepartmentId)
                .ToListAsync();



            StudentMarkVm vm = new StudentMarkVm
            {
                StudentId = student.Id,

                StudentName = student.StudentName,

                Subjects = subjects
                 .Select(s =>
                {
        var existingMark = student.StudentSubjects
            .FirstOrDefault(ss => ss.SubjectId == s.Id);

        return new StudentSubjectVm
        {
            SubjectId = s.Id,
            SubjectName = s.SubjectName,
            Mark = existingMark != null ? existingMark.Mark : 0
        };
             })
                 .ToList()
            };


            return View(vm);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMarks(StudentMarkVm vm)
        {

            foreach (var subject in vm.Subjects)
            {
                var existingMark = await _context.StudentSubjects
                    .FirstOrDefaultAsync(ss =>
                        ss.StudentId == vm.StudentId &&
                        ss.SubjectId == subject.SubjectId);


                if (existingMark != null)
                {
                    existingMark.Mark = subject.Mark;
                }
                else
                {
                    StudentSubject studentSubject = new StudentSubject
                    {
                        StudentId = vm.StudentId,

                        SubjectId = subject.SubjectId,

                        Mark = subject.Mark
                    };

                    _context.StudentSubjects.Add(studentSubject);
                }
            }


            await _context.SaveChangesAsync();


            return RedirectToAction(
                "index",
            "Student"
            
              
            );
        }
        public async Task<IActionResult> Edit(int id)
        {

            var student = await _context.Students
                .FindAsync(id);



            if (student == null)
                return NotFound();



            StudentVm vm = new StudentVm
            {
                Id = student.Id,
                StudentName = student.StudentName,
                StudentId = student.StudentId,
                DepartmentId = student.DepartmentId,
                Departments = await _context.Departments.ToListAsync()
            };


            return View(vm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentVm vm)
        {

            if (ModelState.IsValid)
            {

                var student = await _context.Students
                    .FindAsync(vm.Id);



                if (student == null)
                    return NotFound();



                student.StudentName = vm.StudentName;

                student.StudentId = vm.StudentId;

                student.DepartmentId = vm.DepartmentId;



                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }



            vm.Departments = await _context.Departments
                .ToListAsync();


            return View(vm);
        }

        public async Task<IActionResult> Delete(int id)
        {

            var student = await _context.Students
                .Include(s => s.Department)
                .FirstOrDefaultAsync(s => s.Id == id);



            if (student == null)
                return NotFound();



            return View(student);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var student = await _context.Students
                .FindAsync(id);



            if (student != null)
            {

                _context.Students.Remove(student);

                await _context.SaveChangesAsync();

            }



            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SearchById(string studentId)
        {

            var students = await _context.Students
                .Include(s => s.Department)
                .Where(s => s.StudentId.Contains(studentId))
                .ToListAsync();



            return View("Index", students);
        }

        // Search By Student Name
        public async Task<IActionResult> SearchByName(string name)
        {

            var students = await _context.Students
                .Include(s => s.Department)
                .Where(s => s.StudentName.Contains(name))
                .ToListAsync();



            return View("Index", students);
        }

    }
}