using CarOffers.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOffers.Core.Services
{
    public interface IOfferService
    {
        Task AddNew(OfferInputModel offerInput);
        Task<List<OfferInputModel>> GetAll();
    }
}
