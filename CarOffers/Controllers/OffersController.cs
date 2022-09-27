using Microsoft.AspNetCore.Mvc;

namespace CarOffers.Controllers
{
    public class OffersController : Controller
    {
        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }
    }
}
