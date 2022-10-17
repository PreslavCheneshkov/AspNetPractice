using Microsoft.AspNetCore.Mvc;

namespace TaskBoardApp.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
