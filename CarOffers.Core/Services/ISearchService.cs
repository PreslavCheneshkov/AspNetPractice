using CarOffers.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOffers.Core.Services
{
    public interface ISearchService
    {
        Task<List<OfferSearchModel>> NewSearch(SearchInputModel searchModel);
    }
}
