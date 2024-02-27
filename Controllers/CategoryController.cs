using Inventory.Models;
using Inventory.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{

    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var cats= _categoryService.GetCategories();

            return View("Index",cats);
        }


        [HttpGet]
        public ActionResult Create() => View("Create");
        [HttpPost]
        public ActionResult Create([Bind("CategoryName","Description")] Category category)
        {
            if (!ModelState.IsValid) return View(category);

            var result=_categoryService.Create(category);

            if(result) return RedirectToAction("Index");

            return View(category);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category= _categoryService.GetById(id);
            return View("Edit", category);
        }
        [HttpPost]
        public ActionResult Edit(Category category) 
        {
            if (!ModelState.IsValid) return View(category);
            var result = _categoryService.Update(category);
            return result ? Redirect("/Category/Index"):View(category);   

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = _categoryService.GetById(id);
            return View(category);
        }
        [HttpPost]
        [ActionName("Delete")]  
        public ActionResult ConfirmDelete(int id)
        {
            var result = _categoryService.Delete(id);
            return result ? Redirect("/Category/Index"):BadRequest();
        }

        [HttpGet]
        public ActionResult Details(int id) 
        {
            var category = _categoryService.GetById(id);
            return View(category);
        }

    }
}
