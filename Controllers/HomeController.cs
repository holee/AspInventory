using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class HomeController : Controller
    {


        [HttpGet]
        [ActionName("List")]
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult Create()
        { 
             return View("Create");
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            ViewBag.Name = name;

            return View("Create");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [NonAction]
        public string Test()
        {
            return "Test....";
        }



    }
}
