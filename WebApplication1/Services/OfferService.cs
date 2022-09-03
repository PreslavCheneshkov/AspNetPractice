using WebApplication1.Models;
using System.ComponentModel;
using WebApplication1.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Services
{
    public class OfferService : IOfferService
    {
        private readonly ApplicationDbContext dbContext;

        public OfferService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddOfferAsync(OfferInputModel offerInputModel)
        {
            Offer offer = new Offer
            {
                PictureUrl = offerInputModel.Picture,
                Manufacturer = offerInputModel.Manufacturer,
                Model = offerInputModel.Model,
                Price = offerInputModel.Price,
            };
            await this.dbContext.Offers.AddAsync(offer);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
