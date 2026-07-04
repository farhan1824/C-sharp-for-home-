using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibraryManagementSystem.Controllers
{
   
    public class BooksController : Controller
    {
        private readonly  ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }
        public IActionResult Create()
        {
            var books = new BooksVm();
            return View(books);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( BooksVm books)
        {
            if (ModelState.IsValid)
            {
                //var result = await _context.Books.FirstOrDefaultAsync(b => b.BookId == books.BookId);
                var entity = new Books
                {
                    BookId = books.BookId,
                    Title = books.Title,
                    ISBN = books.ISBN,
                    Price = books.Price,
                    Quantity = books.Quantity,
                    CategoryId = books.CategoryId,
                    AuthorId = books.AuthorId
                };
                _context.Books.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }
            return View(books);
        }

    }
}
