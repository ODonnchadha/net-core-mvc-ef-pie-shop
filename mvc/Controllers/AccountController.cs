using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet()]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet()]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = await this.userManager.FindByNameAsync(viewModel.UserName);

            if (user != null)
            {
                var result = await this.signInManager.PasswordSignInAsync(user, viewModel.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "User Name or Password not found");
            return View(viewModel);
        }

        [HttpPost()]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = viewModel.UserName };
                var result = await this.userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                    await this.signInManager.PasswordSignInAsync(await this.userManager.FindByNameAsync(user.UserName), viewModel.Password, false, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
                }
            }

            return View(viewModel);
        }

        [HttpPost()]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}