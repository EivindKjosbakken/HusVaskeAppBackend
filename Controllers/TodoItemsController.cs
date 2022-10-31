
using HusVaskeIdeBackend.Models.TodoItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Any;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HusVaskeIdeBackend.Controllers 
{ 

    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ILogger<TodoItemsController> _logger;

        private ITodoRepository _repository;
        public TodoItemsController(ILogger<TodoItemsController> logger, ITodoRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("api/todoitems")]

        public IEnumerable<TodoItem> GetAllItems()
        {
            return _repository.GetAllTodoItems();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("api/todoitems/{assignee}")]
        [Consumes("application/json")]
        public IEnumerable<TodoItem> GetAllItemsForAssignee(string assignee)
        {
            return _repository.GetAllItemsForAssignee(assignee);
        }

        [HttpPost]
        [Route("api/todoitem")]
        [Consumes("application/json")]
        public void PostTodoItem([FromBody] TodoItem todoItem)
        {
            _repository.AddTodoItem(todoItem);
        }
    }
}