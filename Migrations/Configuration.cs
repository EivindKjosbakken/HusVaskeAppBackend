namespace HusVaskeIdeBackend.Migrations
{
    using HusVaskeIdeBackend.Models.TodoItem;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HusVaskeIdeBackend.Models.TodoItem.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HusVaskeIdeBackend.Models.TodoItem.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var todoItems = new List<TodoItem> {
                new TodoItem { Title = "Oppvaskmaskin", Location = "Kjøkken", Assignee = "Eivind" }
            };
            todoItems.ForEach(s => context.TodoItems.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();
        }
    }
}
