using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskBoardApp.Data;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskBoardAppDbContext data;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, TaskBoardAppDbContext _data)
        {
            _logger = logger;
            data = _data;
        }

        public IActionResult Index()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}