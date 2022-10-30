using System.Collections.Generic;
using System;
using HusVaskeIdeBackend.Models;

namespace HusVaskeIdeBackend.Models.TodoItem
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> GetAllTodoItems();
        void AddTodoItem(TodoItem todoItem);
    }
}