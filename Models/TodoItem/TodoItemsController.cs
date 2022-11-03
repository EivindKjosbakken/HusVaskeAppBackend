using HusVaskeIdeBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Any;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace HusVaskeIdeBackend.Models.TodoItem
{
    //[Authorize] //TODO fjerna her, husk å bytte tilbake
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("api/unfinishedtodoitems/{assignee}")]
        [Consumes("application/json")]
        public IEnumerable<TodoItem> GetAllUnFinishedItemsForAssignee(string assignee)
        {
            return _repository.GetAllUnFinishedItemsForAssignee(assignee);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("api/finishedtodoitems/{assignee}")]
        [Consumes("application/json")]
        public IEnumerable<TodoItem> GetAllFinishedItemsForAssignee(string assignee)
        {
            return _repository.GetAllFinishedItemsForAssignee(assignee);
        }


        [HttpPost]
        [Route("api/todoitem")]
        [Consumes("application/json")]
        public void PostTodoItem([FromBody] TodoItemInDTO todoItemDto)
        {
            var todoItem = new TodoItem
            {
                Title = todoItemDto.Title,
                Location = todoItemDto.Location,
                Assignee = todoItemDto.Assignee,
                IsFinished = false,
                TimeCreated = DateTime.UtcNow,
                GroupID = todoItemDto.GroupID,
                UserID = todoItemDto.UserID
            };
            _repository.AddTodoItem(todoItem);
        }


        [HttpPut]
        [Route("api/finishtodoitem/{ID:int}")]
        [Consumes("application/json")]
        public void FinishTodoItem(int ID)
        {
            _repository.FinishTodoItem(ID);
        }


        [HttpPut]
        [Route("api/unfinishtodoitem/{ID:int}")]
        [Consumes("application/json")]
        public void UnFinishTodoItem(int ID)
        {
            _repository.UnFinishTodoItem(ID);
        }
    }
}