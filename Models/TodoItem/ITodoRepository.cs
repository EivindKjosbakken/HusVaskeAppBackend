using System.Collections.Generic;
using System;
using HusVaskeIdeBackend.Models;

namespace HusVaskeIdeBackend.Models.TodoItem
{
    public interface ITodoRepository
    {
        public IEnumerable<TodoItem> GetAllTodoItems();
        public IEnumerable<TodoItem> GetAllItemsForAssignee(string assignee);
        public IEnumerable<TodoItem> GetAllUnFinishedItemsForAssignee(string assignee);
        public IEnumerable<TodoItem> GetAllFinishedItemsForAssignee(string assignee);
        public void AddTodoItem(TodoItem todoItem);

        public void FinishTodoItem(int ID);
        public void UnFinishTodoItem(int ID);
    }
}