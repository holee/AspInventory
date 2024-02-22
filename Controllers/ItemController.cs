using Inventory.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Inventory.Controllers
{
    public class ItemController : Controller
    {
        private readonly DataContext context;
        private readonly ApplicationDbContext contextDb;
        public ItemController(DataContext context, ApplicationDbContext contextDb)
        {
            this.context = context;
            this.contextDb = contextDb;
        }

        public IActionResult Index()
        {  
            var items=contextDb.Items
                        .Include(x=>x.Category)
                        //.Include(x=>x.Supplier)
                        .ToList();
            return View("Index", items);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var categories=contextDb.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Store(Item req)  
        {
            var cat=contextDb.Categories
                        .Include(x=>x.Items)
                        .FirstOrDefault(x=>x.Id==req.CateId);
            if (cat is null) return BadRequest();
            cat.Items!.Add(req);
            contextDb.SaveChanges();
            TempData["message"] = "Created Successfully.";
            return RedirectToAction(nameof(Index));
        }



    }
}


//var sql = "SELECT * FROM categories";
//using SqlCommand cmd=new SqlCommand(sql);
//cmd.CommandType= System.Data.CommandType.Text;  
//cmd.Connection = context.Connection;
//SqlDataReader reader = cmd.ExecuteReader();
//DataTable table = new DataTable();
//table.Load(reader);

//var cats = table.AsEnumerable().Select(x => new Category
//{
//    Id=x.Field<int>(0),
//    CategoryName= x.Field<string>(1),
//    Description= x.Field<string>(2),
//});

//ViewBag.cats = new SelectList(cats, "Id", "CategoryName");
//ViewData["categories"]= new SelectList(cats, "Id", "CategoryName");
//var sql = "SELECT * FROM items";

//using SqlCommand cmd=new SqlCommand(sql);
//cmd.CommandType=System.Data.CommandType.Text;
//cmd.Connection = context.Connection;
//SqlDataReader reader = cmd.ExecuteReader();
//DataTable table = new DataTable();
//table.Load(reader);

//var items = table.AsEnumerable().Select(x => new Item
//{
//    Id=x.Field<int>("Id"),
//    //CateId=x.Field<int>("CateId"),
//    SupplierRefId= x.Field<int>("SupplierRefId"),
//    ProductCode= x.Field<string>("ProductCode")!,
//    ProductName= x.Field<string>("ProductName")!,
//    CateId = x.Field<int>("CateId")!,
//    StandardPrice = x.Field<decimal>("StandardPrice"),
//    ImageUrl= x.Field<string>("ImageUrl"),
//}).ToList();
