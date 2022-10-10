using CarOffers.Core.Data;
using CarOffers.Core.Data.Entities;
using CarOffers.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOffers.Core.Services
{
    public class OfferService : IOfferService
    {
        private readonly ApplicationDbContext context;
        public OfferService(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task AddNew(OfferInputModel offerInput)
        {
            var offer = new Offer()
            {
                Manufacturer = offerInput.Manufacturer,
                Model = offerInput.Model,
                Mileage = offerInput.Mileage,
                Year = offerInput.Year,
                Price = offerInput.Price,
                PictureUrl = offerInput.PictureUrl,
            };
            await context.Offers.AddAsync(offer);
            await context.SaveChangesAsync();
        }

        public async Task<List<OfferInputModel>> GetAll()
        {
            return await context.Offers
                          .Select(o => new OfferInputModel()
                          {
                              Manufacturer = o.Manufacturer,
                              Model = o.Model,
                              Mileage = o.Mileage,
                              Year = o.Year,
                              Price = o.Price,
                              PictureUrl = o.PictureUrl,
                          }).ToListAsync();
        }
    }
}
