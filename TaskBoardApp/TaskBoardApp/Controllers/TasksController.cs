using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;
using System.Linq;
using TaskBoardApp.Data.Entities;

namespace TaskBoardApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public TasksController(TaskBoardAppDbContext _data)
        {
            data = _data;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel taskModel = new TaskFormModel()
            {
                Boards = await GetBoards()
            };

            return View(taskModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskModel)
        {
            var getBoards = await GetBoards();
            if (!getBoards.Any(b => b.Id == taskModel.BoardId))
            {
                this.ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            string currentUserID = GetUserId();
            Data.Entities.Task task = new Data.Entities.Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserID,
            };

            await this.data.Tasks.AddAsync(task);
            await this.data.SaveChangesAsync();

            var boards = this.data.Boards;

            return RedirectToAction("All", "Boards");
        }
        public async Task<IActionResult> Details(int id)
        {
            var task = await this.data
                            .Tasks
                            .Where(t => t.Id == id)
                            .Select(t => new TaskDetailsViewModel()
                            {
                                Id = t.Id,
                                Title = t.Title,
                                Description = t.Description,
                                CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                                Board = t.Board.Name,
                                Owner = t.Owner.UserName,
                            }).FirstOrDefaultAsync();
            if (task == null)
            {
                return BadRequest();
            }
            return View(task);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Data.Entities.Task task = await data.Tasks.FindAsync(id);
            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel taskModel = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = await GetBoards(),
            };

            return View(taskModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
        {
            Data.Entities.Task task = await data.Tasks.FindAsync(id);
            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }
            var boards = await GetBoards();
            if (!boards.Any(b => b.Id == taskModel.BoardId))
            {
                this.ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;

            await this.data.SaveChangesAsync();
            return RedirectToAction("All", "Boards");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Data.Entities.Task task = await data.Tasks.FindAsync(id);
            if (task == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }
            TaskViewModel taskModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
            };

            return View(taskModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskModel)
        {
            Data.Entities.Task task = await data.Tasks.FindAsync(taskModel.Id);
            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }
            this.data.Tasks.Remove(task);
            await this.data.SaveChangesAsync();
            return RedirectToAction("All", "Boards");
        }
        private async Task<IEnumerable<TaskBoardModel>> GetBoards()
        {
            var boards = await data.Boards
                                .Select(b => new TaskBoardModel()
                                {
                                    Id = b.Id,
                                    Name = b.Name,
                                }).ToListAsync();
            return boards;
        }
        private string GetUserId()
        {
            var id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return id;
        }
    }
}
