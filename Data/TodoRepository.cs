
using System.Collections.Generic;
using System.Linq;
using HusVaskeIdeBackend.Models.TodoItem;

namespace HusVaskeIdeBackend.Data
{
    public class TodoRepository : ITodoRepository
    {
        private List<TodoItem> _todoList;
        private int _nextId = 1;
        public TodoRepository()
        {
            InitializeData();
        }

        public IEnumerable<TodoItem> All
        {
            get { return _todoList; }
        }

        public bool DoesItemExist(int id)
        {
            return _todoList.Any(item => item.ID == id);
        }

        public TodoItem Find(int id)
        {
            return _todoList.FirstOrDefault(item => item.ID == id);
        }

        public TodoItem Insert(TodoItem item)
        {
            item.ID = _nextId++;

            _todoList.Add(item);
            return item;
        }

        public void Update(TodoItem item)
        {
            var todoItem = this.Find(item.ID);
            var index = _todoList.IndexOf(todoItem);
            _todoList.RemoveAt(index);
            _todoList.Insert(index, item);
        }

        public void Delete(int id)
        {
            _todoList.Remove(this.Find(id));
        }

        private void InitializeData()
        {
            _todoList = new List<TodoItem>();

            var todoItem1 = new TodoItem
            {
                ID = 1,
                Title = "EIVIND HAR API EN! ! ! !",
                Location = "Take Microsoft Learn Courses",
                Assignee = "Eivind",
            };

            var todoItem2 = new TodoItem
            {
                ID = 2,
                Title = "Develop apps",
                Location = "Use Visual Studio and Visual Studio for Mac",
                Assignee = "Bernt",
            };

            var todoItem3 = new TodoItem
            {
                ID = 3,
                Title = "Publish apps",
                Location = "All app stores",
                Assignee = "Erik",
            };

            _todoList.Add(todoItem1);
            _todoList.Add(todoItem2);
            _todoList.Add(todoItem3);
        }
    }
}