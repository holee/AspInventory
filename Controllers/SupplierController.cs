using Inventory.Data;
using Inventory.Models;
using Inventory.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService service;
        private readonly ApplicationDbContext cxt;
        public SupplierController(ISupplierService service, ApplicationDbContext cxt)
        {
            this.service = service;
            this.cxt = cxt;
        }
        public async Task<IActionResult> Index(int id)
        {

            var suppliers =await cxt.Suppliers
                                .Include(x => x.Address)
                                .ToListAsync();

            return View(suppliers);

            //Adding to Related Entity

            //var sp = cxt.Suppliers.FirstOrDefault(x => x.Id == id) ;

            //var address = new Address
            //{
            //    City = "Phnom Penh",
            //    ProvinceName = "Battambang",
            //    DistrictName = "Sagnke",
            //    CommuneName = "Sangke",
            //    Village = "Svaypor"
            //};

            //sp!.Address = address;
            ////cxt.Suppliers.Add(sp);
            //await cxt.SaveChangesAsync();
            ////Add A Gragh of New Entities
            //var sp1 = new Supplier
            //{
            //    Name = "New Supplier",
            //    Email = "test@email.com",
            //    City = "Phnom Penh",
            //    Description = "My Description",
            //    Gender = "Male",
            //    Address = new Address
            //    {
            //        City = "Phnom Penh",
            //        ProvinceName = "Battambang",
            //        DistrictName = "Sagnke",
            //        CommuneName = "Sangke",
            //        Village = "Svaypor"
            //    }
            //};

            //cxt.Suppliers.Add(sp1);
            //await cxt.SaveChangesAsync();

            //var results=await service.GetAll();
            //return View(results);

        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var supplier = await service.Get(id);
            return View(supplier);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id) 
        {
            var supplier = await service.Get(id);
            return Ok(supplier);
        }




        [HttpGet]
        public async Task<IActionResult> Delete(int id) 
        {
            var pro = cxt.Suppliers
                            .Include(x => x.Address)
                            .Where(x=>x.Id == id)
                            .First();
            //var address = pro.Address;
            cxt.Addresses.Remove(pro!.Address!);
           await cxt.SaveChangesAsync();
            return Ok();
            //var supplier = await service.Get(id);
            //return Ok(supplier);
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
            var supplier = await service.Get(id);
            await Task.CompletedTask;
            return View(supplier);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Update(int id,Supplier supplier)
        {
            if (!ModelState.IsValid && id!=supplier.Id)
            {
                return View(supplier);
            }
            if (await service.Update(supplier))
            {
                return RedirectToAction("Index");
            }
            return View(supplier);
        }
    }
}
