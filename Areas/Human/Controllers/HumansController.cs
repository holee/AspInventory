using Microsoft.AspNetCore.Mvc;

namespace Inventory.Areas.Human.Controllers
{
    public class HumansController:Controller
    {
        public ActionResult Index()
        {
            return Content("Human Area");
        }
    }
}
