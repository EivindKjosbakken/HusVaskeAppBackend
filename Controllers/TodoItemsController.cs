using HusVaskeIdeBackend.Models.TodoItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class TodoItemsController : ControllerBase
{
    private TodoRepository _repository = new TodoRepository();



    [HttpGet]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("api/todoitems")]

    public IEnumerable<TodoItem> GetAllItems()
    {
        return _repository.GetAllTodoItems();
    }


    [HttpPost]
    [Route("api/todoitem")]
    [Consumes("application/json")]
    public void PostTodoItem(TodoItem todoItem)
    {
        _repository.AddTodoItem(todoItem);
    }
}