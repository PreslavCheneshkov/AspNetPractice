using ForumApp.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
    public class ForumAppDbContext : IdentityDbContext
    {
        private Post FirstPost { get; set; }
        private Post SecondPost { get; set; }
        private Post ThirdPost { get; set; }
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }
        public DbSet<Post> Posts { get; init; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedPosts();
            builder
                .Entity<Post>()
                .HasData(this.FirstPost,
                        this.SecondPost,
                        this.ThirdPost);
            base.OnModelCreating(builder);
        }
        private void SeedPosts()
        {
            this.FirstPost = new Post()
            {
                Id = 1,
                Title = "My first post",
                Content = "My first post will be about performing " + "CRUD operations in MVC. It's so much fun!"
            };

            this.SecondPost = new Post()
            {
                Id = 2,
                Title = "My second post",
                Content = "This is my second post. " + "CRUD operations in MVC are getting more and more intereseting!"
            };

            this.ThirdPost = new Post()
            {
                Id = 3,
                Title = "My third post",
                Content = "Hello there! I'm getting better and better with the" + "CRUD operations in MVC. Stay tuned!"
            };
        }
    }
}