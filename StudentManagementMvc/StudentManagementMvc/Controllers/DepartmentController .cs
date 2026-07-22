using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementMvc.Data;
using StudentManagementMvc.Entities;
using StudentManagementMvc.Models;

namespace StudentManagementMvc.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly ApplicationDbContext _context;


        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Department
        public async Task<IActionResult> Index()
        {
            var departments = await _context.Departments
                .ToListAsync();

            return View(departments);
        }



        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }



        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentCreateVm vm)
        {

            if (ModelState.IsValid)
            {

                Department department = new Department()
                {
                    DepartmentName = vm.DepartmentName
                };


                _context.Departments.Add(department);

                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }


            return View(vm);
        }




        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var department = await _context.Departments
                .FindAsync(id);


            if (department == null)
                return NotFound();



            DepartmentEditVm vm = new()
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName
            };


            return View(vm);
        }





        // POST: Department/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            DepartmentEditVm vm)
        {

            if (ModelState.IsValid)
            {

                var department = await _context.Departments
                    .FindAsync(vm.Id);


                if (department == null)
                    return NotFound();



                department.DepartmentName = vm.DepartmentName;


                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));

            }


            return View(vm);
        }





        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.Id == id);



            if (department == null)
                return NotFound();



            return View(department);

        }





        // POST: Department/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var department = await _context.Departments
                .FindAsync(id);



            if (department != null)
            {

                _context.Departments.Remove(department);

                await _context.SaveChangesAsync();

            }


            return RedirectToAction(nameof(Index));
        }

    }
}
