using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Entities;
using Portfolio.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class EducationController : Controller
    {
     
            private readonly ApplicationDbContext _context;
            public EducationController(ApplicationDbContext context) { _context = context; }

            public async Task<IActionResult> Index()
            {
                var educations = await _context.Educations.ToListAsync();


                return View(educations);
            }
            public IActionResult Create()
            {
                //var personalinfo = new EducationVm();
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(EducationVm education)
            {
                if (!ModelState.IsValid)
                {
                    return View(education);
                }

                var entity = new Education
                {
                    Institution = education.Institution,
                    Degree = education.Degree,
                    FieldOfStudy = education.FieldOfStudy,
                    StartDate = education.StartDate,
                    EndDate = education.EndDate,
                    
                };

                _context.Educations.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            public async Task<IActionResult> Edit(int id)
            {
                var info = await _context.Educations.FindAsync(id);
                var model = new EducationVm
                {
                    Institution = info.Institution,
                    Degree = info.Degree,
                    FieldOfStudy = info.FieldOfStudy,
                    StartDate = info.StartDate,
                    EndDate = info.EndDate,
                }; 

                return View(model);
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(EducationVm education)
            {
                if (!ModelState.IsValid)
                {
                    return View(education);
                }

                var entity = await _context.Educations.FindAsync(education.Id);
                if (entity == null)
                {
                    return NotFound();
                }

                entity.Institution = education.Institution;
                entity.Degree = education.Degree;
                entity.FieldOfStudy = education.FieldOfStudy;
                entity.StartDate = education.StartDate;
                entity.EndDate = education.EndDate;
           

           

                _context.Educations.Update(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            public async Task<IActionResult> Delete(int id)

            {

                var infoDelete = await _context.Educations.FindAsync(id);
                var model = new EducationVm
                {
                    Institution = infoDelete.Institution,
                    Degree = infoDelete.Degree,
                    FieldOfStudy = infoDelete.FieldOfStudy,
                    StartDate = infoDelete.StartDate,
                    EndDate = infoDelete.EndDate,

                };

                return View(model);

            }
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var infoDelete = await _context.Educations.FindAsync(id);
                if (infoDelete == null)
                {
                    return NotFound();
                }

                // remove the uploaded file from disk if it exists
                

                _context.Educations.Remove(infoDelete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


        }

    }

