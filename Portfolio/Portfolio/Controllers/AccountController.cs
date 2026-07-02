using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Migrations;
using Portfolio.Entities;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager ,SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var view=new RegistrationVm();
            return View(view);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegistrationVm registration)
        {
            if (!ModelState.IsValid)
            {
                return View(registration);
            }
            else
            {
                var user=new ApplicationUser
                {
                    FullName = registration.FullName,
                    Phone = registration.Phone,
                    Email = registration.Email,
                    Address = registration.Address,
                    UserName = registration.Email
                };
                var result = await _userManager.CreateAsync(user, registration.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(registration);
                }
            }
        }
        public IActionResult Login()
        {
            var view = new LoginVm();
            return View(view);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVm login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            else
            {
                var result = await _signInManager.PasswordSignInAsync(
                    login.Email,
                    login.Password,
                    false,
                    false
                    );
                if (result.Succeeded)
                {
                    return RedirectToAction("PersonalInfo","Index");
                }
                else
                {
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "User is locked out.");
                        return View(login);
                    }
                    else if (result.IsNotAllowed)
                    {
                        ModelState.AddModelError("", "Login not allowed (email not confirmed).");
                        return View(login);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login attempt.");
                        return View(login);
                    }
                }
                //return View(login);
            }
        }
    }
}
