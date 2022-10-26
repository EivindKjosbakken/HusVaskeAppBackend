using HusVaskeIdeBackend.Data;
using HusVaskeIdeBackend.Models.TodoItem;
using HusVaskeIdeBackend.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class TodoItemsController : ControllerBase
{
    private readonly ITodoRepository _todoRepository;

    public TodoItemsController(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("api/todoitems")]

    public IActionResult List()
    {
        return Ok(_todoRepository.All);
    }


    [HttpPost]
    [Route("api/todoitem")]
    [Consumes("application/json")]
    public TodoItem PostItem(TodoItem item)
    {

        return _todoRepository.Insert(item);
    }
}