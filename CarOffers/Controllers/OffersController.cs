using CarOffers.Core.Data;
using CarOffers.Core.Data.Entities;
using CarOffers.Core.Services;
using CarOffers.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarOffers.Controllers
{
    public class OffersController : Controller
    {
        private readonly IOfferService offerService;
        public OffersController(IOfferService _offerService)
        {
            this.offerService = _offerService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult AddNew()
        {
            var model = new OfferInputModel();

            return View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNew(OfferInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            await offerService.AddNew(inputModel);
            
            return RedirectToAction("SeeAll");
        }
        [HttpGet]
        public async Task<IActionResult> SeeAll()
        {
            var offers = await offerService.GetAll();

            return View(offers);
        }
    }
}
