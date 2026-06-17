using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Entities;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class ContactMessageController : Controller
    {
        private readonly ApplicationDbContext _context;
   public ContactMessageController(ApplicationDbContext context) { _context = context; }
        public async Task<IActionResult> Index()
        {
            var educations = await _context.ContactMessages.ToListAsync();


            return View(educations);
        }
        public IActionResult Create()
        {
            //var personalinfo = new EducationVm();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactMessageVm contactMessage)
        {
            if (!ModelState.IsValid)
            {
                return View(contactMessage);
            }

            var entity = new ContactMessage
            {
                Name = contactMessage.Name,
                Email = contactMessage.Email,
                Subject = contactMessage.Subject,
                Message = contactMessage.Message,
                SentAt = contactMessage.SentAt,

            };

            _context.ContactMessages.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var info = await _context.ContactMessages.FindAsync(id);
            var model = new ContactMessageVm
            {
                Name = info.Name,
                Email = info.Email,
                Subject = info.Subject,
                Message = info.Message,
                SentAt = info.SentAt,
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContactMessageVm contactMessage)
        {
            if (!ModelState.IsValid)
            {
                return View(contactMessage);
            }

            var entity = await _context.ContactMessages.FindAsync(contactMessage.Id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = contactMessage.Name;
            entity.Email = contactMessage.Email;
            entity.Subject = contactMessage.Subject;
            entity.Message = contactMessage.Message;
            entity.SentAt = contactMessage.SentAt;




            _context.ContactMessages.Update(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)

        {

            var infoDelete = await _context.ContactMessages.FindAsync(id);
            var model = new ContactMessageVm
            {
                Name = infoDelete.Name,
                Email = infoDelete.Email,
                Subject = infoDelete.Subject,
                Message = infoDelete.Message,
                SentAt = infoDelete.SentAt,

            };

            return View(model);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infoDelete = await _context.ContactMessages.FindAsync(id);
            if (infoDelete == null)
            {
                return NotFound();
            }

            // remove the uploaded file from disk if it exists


            _context.ContactMessages.Remove(infoDelete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
