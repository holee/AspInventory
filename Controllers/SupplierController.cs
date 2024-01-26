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
            //var results=await service.GetAll();
            //return View(results);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var supplier = await service.Get(id);
            return View(supplier);
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


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //var supplier = await service.Get(id);
            await Task.CompletedTask;
            return View(new Supplier());
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Update(int id,Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return View(supplier);
            }
            if (await service.Create(supplier))
            {
                return RedirectToAction("Index");
            }
            return View(supplier);
        }
    }
}
