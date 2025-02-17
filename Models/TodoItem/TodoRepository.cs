﻿
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using HusVaskeIdeBackend.Data;

namespace HusVaskeIdeBackend.Models.TodoItem
{
    public class TodoRepository : ITodoRepository
    {
        //private DatabaseContext _context = new DatabaseContext();
        private AppDbContext _context;

        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<TodoItem> GetAllTodoItems()
        {
            return _context.TodoItems.ToList();
        }

        public IEnumerable<TodoItem> GetAllItemsForAssignee(string assignee)
        {
            return _context.TodoItems.Where(obj => obj.Assignee == assignee).ToList();
        }

        public IEnumerable<TodoItem> GetAllUnFinishedItemsForAssignee(string assignee)
        {
            return _context.TodoItems.Where(obj => (obj.Assignee == assignee && obj.IsFinished == false)).ToList();
        }

        public IEnumerable<TodoItem> GetAllFinishedItemsForAssignee(string assignee)
        {
            return _context.TodoItems.Where(obj => (obj.Assignee == assignee && obj.IsFinished == true)).ToList();
        }

        public void AddTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            _context.SaveChanges();
        }

        public void FinishTodoItem(int ID)
        {
            TodoItem itemToUpdate = _context.TodoItems.FirstOrDefault(obj => obj.ID == ID);
            itemToUpdate.IsFinished = true;
            _context.SaveChanges();
        }

        public void UnFinishTodoItem(int ID)
        {
            TodoItem itemToUpdate = _context.TodoItems.FirstOrDefault(obj => obj.ID == ID);
            itemToUpdate.IsFinished = false;
            _context.SaveChanges();
        }

    }
}