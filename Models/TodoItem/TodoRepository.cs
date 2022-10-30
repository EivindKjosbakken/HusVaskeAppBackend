
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;



namespace HusVaskeIdeBackend.Models.TodoItem
{
    public class TodoRepository 
    {
        private DatabaseContext _context = new DatabaseContext();

        public IEnumerable<TodoItem> GetAllTodoItems()
        {
            return _context.TodoItems.ToList();
        }

        public void AddTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            _context.SaveChanges();
        }

    }
}