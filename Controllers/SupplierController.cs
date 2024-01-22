using Inventory.Models;
using Inventory.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService service;

        public SupplierController(ISupplierService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            var results= service.GetAll();
            return View(await results);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Store(Supplier supplier)  
        { 
            if(!ModelState.IsValid)
            {
                return View(supplier);
            }
            if(await service.Create(supplier))
            {
                return RedirectToAction("Index");
            }
            return View(supplier);
        }
    }
}
