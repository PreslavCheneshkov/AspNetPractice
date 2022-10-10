using CarOffers.Data;
using CarOffers.Data.Entities;
using CarOffers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarOffers.Controllers
{
    public class OffersController : Controller
    {
        private ApplicationDbContext context;
        public OffersController(ApplicationDbContext _context)
        {
            this.context = _context;
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
            var offer = new Offer()
            {
                Manufacturer = inputModel.Manufacturer,
                Model = inputModel.Model,
                Mileage = inputModel.Mileage,
                Year = inputModel.Year,
            };
            await context.Offers.AddAsync(offer);
            await context.SaveChangesAsync();
            return RedirectToAction("SeeAll");
        }
        [HttpGet]
        public async Task<IActionResult> SeeAll()
        {
            var offers = await context.Offers
                                        .Select(o => new OfferInputModel()
                                        {
                                            Manufacturer = o.Manufacturer,
                                            Model = o.Model,
                                            Mileage = o.Mileage,
                                            Year = o.Year,
                                        }).ToListAsync();

            return View(offers);
        }
    }
}
