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
        public IActionResult Register(RegisterViewModel model)
        {
            var user = new User()
            {
                Email = model.Email,
                UserName = model.Name
            };

            var result = _userManager.CreateAsync(user, model.Password);

            return RedirectToActionPermanent("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            _signInManager.PasswordSignInAsync(
                model.Name,
                model.Password,
                isPersistent: true,
                lockoutOnFailure: false);

            return RedirectToActionPermanent("Index", "Home");
        }
    }
}
