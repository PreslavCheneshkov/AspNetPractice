using Microsoft.AspNetCore.Mvc;

namespace StamoFirstDemo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
