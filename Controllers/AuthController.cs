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
        public IActionResult Login(LoginModel user)
        {
            //if(user.UserName.Length < 3)
            //{
            //    ModelState.AddModelError("", "User Must be at lease 3 characters");
            //}
            //if (user.UserName.Length > 20)
            //{
            //    ModelState.AddModelError(nameof(user.UserName), "User not greater than 20 characters");
            //}

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            return Redirect("/Home");

        }





        public IActionResult CheckUser(string username)
        {
            List<string> users = ["dara","sok","sao","phally","sen"];
            var newUsers=users.Where(x=>x.ToLower()==username.ToLower());
            if (newUsers.Any())
            {
                return Json(data:$"{username} already exist.");
            }
            return Json(data: true);

        }
    }
}
