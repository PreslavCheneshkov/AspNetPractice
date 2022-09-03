using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Services
{
    public interface IOfferService
    {
        Task AddOfferAsync(OfferInputModel offerInputModel);
    }
}
