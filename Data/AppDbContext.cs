
using HusVaskeIdeBackend.Models.TodoItem;
using HusVaskeIdeBackend.Models.User;
using Microsoft.EntityFrameworkCore;

namespace HusVaskeIdeBackend.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<UserItem> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Code to seed data
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem { ID = 1, Title = "Oppvask", Location="Oslo", Assignee="Eivind" });

            modelBuilder.Entity<UserItem>().HasData(
                new UserItem { Id = "1", Username = "Kjosbakken", Email = "eivind@gmail.com", Password = "123" });

        }
    }
}

