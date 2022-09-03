using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class OffersController : Controller
    {
        private readonly IOfferService offerService;

        public OffersController([FromServices]IOfferService offerService)
        {
            this.offerService = offerService;
        }
        public IActionResult SeeAll()
        {
            return View();
        }

        public IActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNew([FromForm]string picture, [FromForm]string manufacturer, [FromForm] string model, [FromForm]decimal price)
        {
            OfferInputModel inputModel = new OfferInputModel(picture, manufacturer, model, price);
            await this.offerService.AddOfferAsync(inputModel);

            return View("SeeAll");
        }
    }
}
