using System.Collections.Generic;
using HusVaskeIdeBackend.Models.TodoItem;

namespace HusVaskeIdeBackend.Data
{
    public interface ITodoRepository
    {
        bool DoesItemExist(int id);
        IEnumerable<TodoItem> All { get; }
        TodoItem Find(int id);
        TodoItem Insert(TodoItem item);
        void Update(TodoItem item);
        void Delete(int id);
    }
}