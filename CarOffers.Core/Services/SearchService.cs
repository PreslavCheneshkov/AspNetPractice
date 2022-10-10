using CarOffers.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using CarOffers.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace CarOffers.Core.Services
{
    public class SearchService : ISearchService
    {
        private readonly ApplicationDbContext context;
        public SearchService(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<List<OfferSearchModel>> NewSearch(SearchInputModel searchModel)
        {
            return await ApplyFilters(searchModel);

        }
        private async Task<List<OfferSearchModel>> ApplyFilters(SearchInputModel searchModel)
        {
            List<OfferSearchModel> searchOffers = null!;

            bool hasInfoFromDb = false;

            if (searchModel.Manufacturer != null)
            {
                searchOffers = await context.Offers.Where(o => o.Manufacturer == searchModel.Manufacturer)
                                                    .Select(o => new OfferSearchModel
                                                    {
                                                        Manufacturer = o.Manufacturer,
                                                        Model = o.Model,
                                                        Mileage = o.Mileage,
                                                        Year = o.Year,
                                                        Price = o.Price,
                                                        PictureUrl = o.PictureUrl,
                                                    })
                                                    .ToListAsync();     
                hasInfoFromDb= true;
            }
            if (searchModel.Model != null)
            {
                searchOffers = searchOffers.Where(so => so.Model == searchModel.Model).ToList();
            }
            if (searchModel.ToMileage != null)
            {
                if (hasInfoFromDb)
                {
                    searchOffers = searchOffers.Where(so => so.Mileage <= searchModel.ToMileage).ToList();
                }
                else
                {
                    searchOffers = await context.Offers.Where(o => o.Mileage <= searchModel.ToMileage)
                                                    .Select(o => new OfferSearchModel
                                                    {
                                                        Manufacturer = o.Manufacturer,
                                                        Model = o.Model,
                                                        Mileage = o.Mileage,
                                                        Year = o.Year,
                                                        Price = o.Price,
                                                        PictureUrl = o.PictureUrl,
                                                    })
                                                    .ToListAsync();
                    hasInfoFromDb = true;
                }
            }
            if (searchModel.FromYear != null)
            {
                if (hasInfoFromDb)
                {
                    searchOffers = searchOffers.Where(so => so.Year >= searchModel.FromYear).ToList();
                }
                else
                {
                    searchOffers = await context.Offers.Where(o => o.Year >= searchModel.FromYear)
                                                    .Select(o => new OfferSearchModel
                                                    {
                                                        Manufacturer = o.Manufacturer,
                                                        Model = o.Model,
                                                        Mileage = o.Mileage,
                                                        Year = o.Year,
                                                        Price = o.Price,
                                                        PictureUrl = o.PictureUrl,
                                                    })
                                                    .ToListAsync();
                    hasInfoFromDb = true;
                }
            }
            if (searchModel.ToYear != null)
            {
                if (hasInfoFromDb)
                {
                    searchOffers = searchOffers.Where(so => so.Year <= searchModel.ToYear).ToList();
                }
                else
                {
                    searchOffers = await context.Offers.Where(o => o.Year <= searchModel.ToYear)
                                                    .Select(o => new OfferSearchModel
                                                    {
                                                        Manufacturer = o.Manufacturer,
                                                        Model = o.Model,
                                                        Mileage = o.Mileage,
                                                        Year = o.Year,
                                                        Price = o.Price,
                                                        PictureUrl = o.PictureUrl,
                                                    })
                                                    .ToListAsync();
                    hasInfoFromDb = true;
                }
            }
            if (searchModel.FromPrice != null)
            {
                if (hasInfoFromDb)
                {
                    searchOffers = searchOffers.Where(so => so.Price >= searchModel.FromPrice).ToList();
                }
                else
                {
                    searchOffers = await context.Offers.Where(o => o.Price >= searchModel.FromPrice)
                                                    .Select(o => new OfferSearchModel
                                                    {
                                                        Manufacturer = o.Manufacturer,
                                                        Model = o.Model,
                                                        Mileage = o.Mileage,
                                                        Year = o.Year,
                                                        Price = o.Price,
                                                        PictureUrl = o.PictureUrl,
                                                    })
                                                    .ToListAsync();
                    hasInfoFromDb = true;
                }
            }
            if (searchModel.ToPrice != null)
            {
                if (hasInfoFromDb)
                {
                    searchOffers = searchOffers.Where(so => so.Price <= searchModel.ToPrice).ToList();
                }
                else
                {
                    searchOffers = await context.Offers.Where(o => o.Price <= searchModel.ToPrice)
                                                    .Select(o => new OfferSearchModel
                                                    {
                                                        Manufacturer = o.Manufacturer,
                                                        Model = o.Model,
                                                        Mileage = o.Mileage,
                                                        Year = o.Year,
                                                        Price = o.Price,
                                                        PictureUrl = o.PictureUrl,
                                                    })
                                                    .ToListAsync();
                    hasInfoFromDb = true;
                }
            }
            return searchOffers;
        }
    }
}
