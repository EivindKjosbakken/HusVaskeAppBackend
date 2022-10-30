using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace HusVaskeIdeBackend.Models.TodoItem
{
    public class DatabaseContext : DbContext
    {


        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TodoItem>().ToTable("TodoItem");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

