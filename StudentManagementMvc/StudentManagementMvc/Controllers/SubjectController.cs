using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementMvc.Data;
using StudentManagementMvc.Entities;
using StudentManagementMvc.Models;

namespace StudentManagementMvc.Controllers
{
    public class SubjectController : Controller
    {

        private readonly ApplicationDbContext _context;


        public SubjectController(ApplicationDbContext context)
        {
            _context = context;
        }



        // GET: Subject
        public async Task<IActionResult> Index()
        {
            var subjects = await _context.Subjects
                .Include(s => s.Department)
                .ToListAsync();


            return View(subjects);
        }





        // GET: Subject/Create
        public async Task<IActionResult> Create()
        {

            SubjectVm vm = new SubjectVm
            {
                Departments = await _context.Departments.ToListAsync()
            };


            return View(vm);
        }





        // POST: Subject/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubjectVm vm)
        {

            if (ModelState.IsValid)
            {

                Subject subject = new()
                {
                    SubjectName = vm.SubjectName,
                    DepartmentId = vm.DepartmentId
                };


                _context.Subjects.Add(subject);


                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }


            vm.Departments = await _context.Departments.ToListAsync();

            return View(vm);
        }






        // GET: Subject/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var subject = await _context.Subjects
                .FindAsync(id);


            if (subject == null)
                return NotFound();



            SubjectVm vm = new SubjectVm
            {
                Id = subject.Id,
                SubjectName = subject.SubjectName,
                DepartmentId = subject.DepartmentId,
                Departments = await _context.Departments.ToListAsync()
            };


            return View(vm);
        }







        // POST: Subject/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubjectVm vm)
        {

            if (ModelState.IsValid)
            {

                var subject = await _context.Subjects
                    .FindAsync(vm.Id);


                if (subject == null)
                    return NotFound();



                subject.SubjectName = vm.SubjectName;

                subject.DepartmentId = vm.DepartmentId;


                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));

            }


            vm.Departments = await _context.Departments.ToListAsync();


            return View(vm);
        }







        // GET: Subject/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var subject = await _context.Subjects
                .Include(s => s.Department)
                .FirstOrDefaultAsync(s => s.Id == id);



            if (subject == null)
                return NotFound();



            return View(subject);

        }






        // POST: Subject/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var subject = await _context.Subjects
                .FindAsync(id);



            if (subject != null)
            {

                _context.Subjects.Remove(subject);


                await _context.SaveChangesAsync();

            }


            return RedirectToAction(nameof(Index));

        }





        // GET: Subjects By Department
        public async Task<IActionResult> SubjectsByDepartment(int id)
        {

            var subjects = await _context.Subjects
                .Where(s => s.DepartmentId == id)
                .ToListAsync();


            return View(subjects);

        }

    }
}