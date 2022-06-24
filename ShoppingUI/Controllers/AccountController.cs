using Domain.Entites.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingUI.Models.ViewModels.Accountig;

namespace ShoppingUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            var newUser = new User
            {
                FullName = register.FullName,
                Email = register.Email,
                UserName = register.Email,
                PhoneNumber = register.PhoneNumber,

            };

            var result = await userManager.CreateAsync(newUser, register.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            return View(register);

        }


        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            await signInManager.SignOutAsync();
            var userLogin = await userManager.FindByEmailAsync(login.UserName);

            if(userLogin is null)
            {
                ViewData["MessageUserName"] = "this username not found!";
                return View(login);
            }
            var result = await signInManager.PasswordSignInAsync(userLogin, login.Password, login.IsRememberMe, true);

            if (!result.Succeeded)
            {
                ViewData["MessagePassword"] = "your password was incorrect!";
                return View(login);
            }

            return RedirectToAction("Index", "Home");
            
        }

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
