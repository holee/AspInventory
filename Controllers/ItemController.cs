using Inventory.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Inventory.Controllers
{
    public class ItemController : Controller
    {
        private readonly DataContext context;

        public ItemController(DataContext context)
        {
            this.context= context;  
        }

        public IActionResult Index()
        {

            var sql = "SELECT * FROM items";

            using SqlCommand cmd=new SqlCommand(sql);
            cmd.CommandType=System.Data.CommandType.Text;
            cmd.Connection = context.Connection;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);

            var items = table.AsEnumerable().Select(x => new Item
            {
                Id=x.Field<int>("Id"),
                CategoryRefId=x.Field<int>("CategoryRefId"),
                SupplierRefId= x.Field<int>("SupllierRefId"),
                ProductCode= x.Field<string>("ProductCode")!,
                ProductName= x.Field<string>("ProductName")!,
                StandardPrice= x.Field<decimal>("StandardPrice"),
                ImageUrl= x.Field<string>("ImageUrl"),
            }).ToList();

            return View("Index", items);
               // return View(items);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var sql = "SELECT * FROM categories";
            using SqlCommand cmd=new SqlCommand(sql);
            cmd.CommandType= System.Data.CommandType.Text;  
            cmd.Connection = context.Connection;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);

            var cats = table.AsEnumerable().Select(x => new Category
            {
                Id=x.Field<int>(0),
                CategoryName= x.Field<string>(1),
                Description= x.Field<string>(2),
            });

            ViewBag.cats = new SelectList(cats, "Id", "CategoryName");
            ViewData["categories"]= new SelectList(cats, "Id", "CategoryName");


            return View();
        }

        [HttpPost]
        public IActionResult Store(Item req)  
        {
            TempData["message"] = "Created Successfully.";
            return RedirectToAction(nameof(Index));
        }



    }
}
