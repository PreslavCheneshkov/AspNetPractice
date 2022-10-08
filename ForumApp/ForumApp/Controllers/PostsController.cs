using ForumApp.Data;
using ForumApp.Data.Entities;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly ForumAppDbContext data;
        public PostsController(ForumAppDbContext _data)
        {
            this.data = _data;
        }

        public async Task<IActionResult> All()
        {
            var posts = await this.data.Posts
                                    .Select(p => new PostViewModel()
                                    {
                                        Id = p.Id,
                                        Title = p.Title,
                                        Content = p.Content,
                                    })
                                    .ToListAsync();
            return View(posts);
        }

        public IActionResult Add() => View();
        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content,
            };

            await this.data.Posts.AddAsync(post);
            await this.data.SaveChangesAsync();

            return RedirectToAction("All");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var post = await this.data.Posts.FindAsync(id);

            return View(new PostFormModel()
            {
                Title = post.Title,
                Content = post.Content,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormModel model)
        {
            var post = await this.data.Posts.FindAsync(id);
            post.Title = model.Title;
            post.Content = model.Content;

            await this.data.SaveChangesAsync();

            return this.RedirectToAction("All");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await this.data.Posts.FindAsync(id);

            this.data.Posts.Remove(post);
            await this.data.SaveChangesAsync();

            return RedirectToAction("All");
        }
    }
}
