using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<Registrations> _userManager;
        private readonly SignInManager<Registrations> _signInManager;
        public AccountsController(UserManager<Registrations> userManager, SignInManager<Registrations> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var view = new RegistrationsVm();
            return View(view);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegistrationsVm model)
        {
            if (ModelState.IsValid)
            {
                var user = new Registrations
                {
                    UserName = model.Email,
                    Email = model.Email,
                    StudentId = model.StudentId,
                    FullName = model.FullName
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        public IActionResult Login()
        {
            var view = new LoginVm();
            return View(view);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVm model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email,
                    model.Password,
                    false,
                    false
                );

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Account is locked.");
                }
                else if (result.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Login not allowed.");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            return View(model);
        }

    }
}
