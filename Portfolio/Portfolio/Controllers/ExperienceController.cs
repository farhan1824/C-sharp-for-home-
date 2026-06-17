using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Entities;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ExperienceController(ApplicationDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var experiences = await _context.Experiences.ToListAsync();


            return View(experiences);
        }
        public IActionResult Create()
        {
            //var personalinfo = new EducationVm();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExperienceVm experience)
        {
            if (!ModelState.IsValid)
            {
                return View(experience);
            }

            var entity = new Experience
            {
                Company = experience.Company,
                Role = experience.Role,
                Description = experience.Description,
                StartDate = experience.StartDate,
                EndDate = experience.EndDate,

            };

            _context.Experiences.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var info = await _context.Experiences.FindAsync(id);
            var model = new ExperienceVm
            {
                Company = info.Company,
                Role = info.Role,
                Description = info.Description,
                StartDate = info.StartDate,
                EndDate = info.EndDate,
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExperienceVm experience)
        {
            if (!ModelState.IsValid)
            {
                return View(experience);
            }

            var entity = await _context.Experiences.FindAsync(experience.Id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.Company = experience.Company;
            entity.Role = experience.Role;
            entity.Description = experience.Description;
            entity.StartDate = experience.StartDate;
            entity.EndDate = experience.EndDate;




            _context.Experiences.Update(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)

        {

            var info= await _context.Experiences.FindAsync(id);
            var model = new ExperienceVm
            {
                Company = info.Company,
                Role = info.Role,
                Description = info.Description,
                StartDate = info.StartDate,
                EndDate = info.EndDate,

            };

            return View(model);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infoDelete = await _context.Experiences.FindAsync(id);
            if (infoDelete == null)
            {
                return NotFound();
            }

            // remove the uploaded file from disk if it exists


            _context.Experiences.Remove(infoDelete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }


}
