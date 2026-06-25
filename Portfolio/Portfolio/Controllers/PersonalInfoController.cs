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
    public class PersonalInfoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PersonalInfoController(ApplicationDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var personalInfo = await _context.PersonalInfos.ToListAsync();


            return View(personalInfo);
        }
        public IActionResult Create() {
            //var personalinfo = new PersonalinfoVm();
            return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonalinfoVm personalinfo)
        {
            if (!ModelState.IsValid)
            {
                return View(personalinfo);
            }

            var entity = new PersonalInfo
            {
                FullName = personalinfo.FullName,
                Title = personalinfo.Title,
                Email = personalinfo.Email,
                Phone = personalinfo.Phone,
                Address = personalinfo.Address,
                Website = personalinfo.Website,
                LinkedIn = personalinfo.LinkedIn,
                GitHub = personalinfo.GitHub,
                Bio = personalinfo.Bio
            };

            if (personalinfo.profilephoto != null)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string filename = Guid.NewGuid().ToString() + "_" + Path.GetExtension(personalinfo.profilephoto.FileName);
                string filePath = Path.Combine(folder, filename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await personalinfo.profilephoto.CopyToAsync(stream);
                }
                entity.ProfileImageUrl = filename;
            }

            _context.PersonalInfos.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var info = await _context.PersonalInfos.FindAsync(id);
            var model = new PersonalinfoVm
            {
                FullName = info.FullName,
                Title = info.Title,
                Email = info.Email,
                Phone = info.Phone,
                Address = info.Address,
                Website = info.Website,
                LinkedIn = info.LinkedIn,
                GitHub = info.GitHub,
                Bio = info.Bio,
                ProfileImageUrl=info.ProfileImageUrl,

            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonalinfoVm personalinfo)
        {
            if (!ModelState.IsValid)
            {
                return View(personalinfo);
            }

            var entity = await _context.PersonalInfos.FindAsync(personalinfo.Id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.FullName = personalinfo.FullName;
            entity.Title = personalinfo.Title;
            entity.Email = personalinfo.Email;
            entity.Phone = personalinfo.Phone;
            entity.Address = personalinfo.Address;
            entity.Website = personalinfo.Website;
            entity.LinkedIn = personalinfo.LinkedIn;
            entity.GitHub = personalinfo.GitHub;
            entity.Bio = personalinfo.Bio;

            if (personalinfo.profilephoto != null)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string filename = Guid.NewGuid().ToString() + "_" + Path.GetExtension(personalinfo.profilephoto.FileName);
                string filePath = Path.Combine(folder, filename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await personalinfo.profilephoto.CopyToAsync(stream);
                }
                entity.ProfileImageUrl = filename;
            }
            else
            {
                // keep existing image if none uploaded
                // only update if incoming value is not null/empty
                if (!string.IsNullOrEmpty(personalinfo.ProfileImageUrl))
                {
                    entity.ProfileImageUrl = personalinfo.ProfileImageUrl;
                }
            }

            _context.PersonalInfos.Update(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)

        {

            var infoDelete = await _context.PersonalInfos.FindAsync(id);
            var model = new PersonalinfoVm
            {
                FullName = infoDelete.FullName,
                Title = infoDelete.Title,
                Email = infoDelete.Email,
                Phone = infoDelete.Phone,
                Address = infoDelete.Address,
                Website = infoDelete.Website,
                LinkedIn = infoDelete.LinkedIn,
                GitHub = infoDelete.GitHub,
                Bio = infoDelete.Bio,
                ProfileImageUrl = infoDelete.ProfileImageUrl,

            };

            return View(model);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infoDelete = await _context.PersonalInfos.FindAsync(id);
            if (infoDelete == null)
            {
                return NotFound();
            }

            // remove the uploaded file from disk if it exists
            if (!string.IsNullOrEmpty(infoDelete.ProfileImageUrl))
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", infoDelete.ProfileImageUrl);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _context.PersonalInfos.Remove(infoDelete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details()
        {
            var personalInfo = await _context.PersonalInfos
                .FirstOrDefaultAsync();

            var model = new ProfileViewVm
            {
                PersonalInfo = personalInfo != null ? new PersonalinfoVm
                {
                    FullName = personalInfo.FullName,
                    Email = personalInfo.Email,
                    Phone = personalInfo.Phone,
                    Address = personalInfo.Address,
                } : null,

                Skills = await _context.Skills.ToListAsync(),
                Education = await _context.Educations.ToListAsync(),
                Experience = await _context.Experiences.ToListAsync()
            };

            return View(model);
        }
    }

}

