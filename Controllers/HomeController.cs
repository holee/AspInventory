using Inventory.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{

   
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext cxt;

        public HomeController(ApplicationDbContext cxt)
        {
            this.cxt = cxt;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ViewResult Index()
        {

            //var customer = new Customer
            //{
            //    Name="Mon Minh",
            //    Phone="093-456-890"
            //};

            //var emp=cxt.Employees.FirstOrDefault();
            //var cust = cxt.Customers.OrderByDescending(x => x.Id).Last();
            //var cust = new Customer
            //{
            //    Name="Tong",
            //    Phone="099-888-789"
            //};

            //cust!.Employees!.Add(emp!);
            //cxt.Customers.Add(cust);
            //cxt.Employees.Add(employee);
            //emp.Customers!.Add(cust);

            //var order = new Order
            //{
            //    Employee = emp,
            //    Customer = cust,
            //    OrderDate = DateTime.Now,
            //    Total = 10000,
            //    Discount = 2000,
            //    OrderLines = new List<OrderLine>
            //    {
            //        new OrderLine
            //        {
            //            ItemRefId =1,
            //            Quantity=300,
            //            Price=2000,
            //            Discount=0,
            //        },
            //        new OrderLine
            //        {
            //            ItemRefId = 2,
            //            Quantity = 500,
            //            Price = 2000,
            //            Discount = 0,
            //        }
            //    }
            //};
            //cxt.Orders.Add(order);
            //cxt.SaveChanges();

            //var order = new Order
            //{
            //    Employee= employee,
            //    Customer=customer,
            //    OrderDate = DateTime.Now,
            //    Total = 10000,
            //    Discount = 2000,
            //    OrderLines =new List<OrderLine>
            //    {
            //        new OrderLine
            //        {
            //            ItemRefId =1,
            //            Quantity=10,
            //            Price=2000,
            //            Discount=0,
            //            SubTotal=0,
            //        },
            //        new OrderLine
            //        {
            //            ItemRefId = 2,
            //            Quantity = 100,
            //            Price = 2000,
            //            Discount = 0,
            //            SubTotal = 0,
            //        }
            //    }
            //};
            //cxt.Orders.Add(order);  
            //cxt.SaveChanges();
            return View("Index");
        }

        [HttpGet]
        [Authorize]
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

        public string Test()
        {
            return "Test....";
        }



    }
}
