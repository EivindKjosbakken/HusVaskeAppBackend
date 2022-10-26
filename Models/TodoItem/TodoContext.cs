
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace HusVaskeIdeBackend.Models.TodoItem
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }
}