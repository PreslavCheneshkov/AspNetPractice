using CarOffers.Core.Models;
using CarOffers.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarOffers.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService searchService;
        public SearchController(ISearchService _searchService)
        {
            searchService = _searchService;
        }
        [HttpGet]
        public IActionResult NewSearch()
        {
            var search = new SearchInputModel();
            return View(search);
        }
        [HttpPost]
        public async Task<IActionResult> NewSearch(SearchInputModel search)
        {
            throw new NotImplementedException();
        }
    }
}
