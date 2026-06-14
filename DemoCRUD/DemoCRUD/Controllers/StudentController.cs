using DemoCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DemoCRUD.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Create()
        {
            var newStudent = new Student()
            {
                ID = students.Count > 0
                    ? students.Max(s => s.ID) + 1
                    : 1
            };

            return View(newStudent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                students.Add(student);
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            var existingStudent = students.FirstOrDefault(s => s.ID == student.ID);

            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.Name = student.Name;
            existingStudent.Age = student.Age;
            existingStudent.Class = student.Class;
            existingStudent.Address = student.Address;


            return RedirectToAction("Index");
        }

    }
}