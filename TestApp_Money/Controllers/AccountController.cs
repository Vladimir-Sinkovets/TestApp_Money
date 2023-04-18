using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestApp_Money.Entites.Models;
using TestApp_Money.Web.Models;

namespace TestApp_Money.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
        {
            var user = new User()
            {
                Email = model.Email,
                UserName = model.Name
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
                return RedirectToActionPermanent("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(
                model.Name,
                model.Password,
                isPersistent: true,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToActionPermanent("Index", "Home");
            }

            return View(model);
        }
        
        [HttpGet]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();

            return RedirectToActionPermanent("Login", "Account");
        }

    }
}
