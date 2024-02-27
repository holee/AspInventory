using Inventory.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        public ActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

        public ActionResult Create() => View("Register");


        [HttpPost]
        public async Task<ActionResult> Create(RegisterModel model)
        {
            if (!ModelState.IsValid) return View("Register", model);

            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                return View("Register", model);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            return Redirect("/Account/Index");
        }

        public IActionResult Login(string? returnUrl=null) {
            returnUrl ??= Url.Content("/Home");
            ViewBag.returnUrl=returnUrl;
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string? returnUrl = null)
        {
            returnUrl ??= Url.Content("/Home");
            ViewBag.returnUrl = returnUrl;
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByEmailAsync(model.UserName);
            if (user is null)
            {
                ModelState.AddModelError("", $"There is no user resgiste with this {model.UserName} email");
                return View(model);
            }
            var signinResule = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

            if (!signinResule.Succeeded)
            {
                ModelState.AddModelError("", "Invalid UserName And/Or Password");
                return View(model);
            }
            return LocalRedirect(returnUrl!);
           

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Redirect("/Home");
        }


        public IActionResult CheckUser(string username)
        {
            List<string> users = ["dara", "sok", "sao", "phally", "sen"];
            var newUsers = users.Where(x => x.ToLower() == username.ToLower());
            if (newUsers.Any())
            {
                return Json(data: $"{username} already exist.");
            }
            return Json(data: true);

        }
    }
}
