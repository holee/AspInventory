using Inventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(UserModel user) =>Content($"{user.UserName} {user.Password}");

    }
}
