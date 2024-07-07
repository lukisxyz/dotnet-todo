using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Models;

namespace Todo.Api.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class TodoController : Controller
  {

    private readonly DataSource _dataSource;
    public TodoController(DataSource dataSource)
    {
      _dataSource = dataSource;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetTodos()
    {
      var todoList = _dataSource.TodoLists;
      return Ok(todoList);
    }

    [Route("{id}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetTodoByID(string id)
    {
      var todoList = _dataSource.TodoLists;
      var result = todoList.FirstOrDefault(t => t.Id == id);
      if (result == null) 
      {
        return NotFound("Data with specify id not found");
      }

      return Ok(result);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult CreateTodo([FromBody] TodoItemInputModel input)
    {
      var todoItem = new TodoItem
      {
        Title = input.Title,
        Description = input.Description,
        Deadline = input.Deadline
      };

      if (!todoItem.IsValid())
      {
          return BadRequest();
      }

      _dataSource.TodoLists.Add(todoItem);
      return Ok(todoItem);
    }

    [Route("{id}")]
    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdateTodo([FromBody] TodoItemInputModel input, [FromRoute] string id)
    {
      var todoList = _dataSource.TodoLists;
      var currentTodo = todoList.FirstOrDefault(t => t.Id == id);
      if (currentTodo == null) 
      {
        return NotFound("Data with specify id not found");
      }


      var todoItem = new TodoItem
      {
        Title = input.Title,
        Description = input.Description,
        Deadline = input.Deadline
      };

      if (!todoItem.IsValid())
      {
          return BadRequest();
      }
      
      _dataSource.TodoLists.Remove(currentTodo);

      currentTodo.Title = todoItem.Title;
      currentTodo.Description = todoItem.Description;
      currentTodo.Deadline = todoItem.Deadline;
      currentTodo.UpdatedAt = DateTime.Now;

      _dataSource.TodoLists.Add(currentTodo);

      return Ok(currentTodo);

    }

    [Route("{id}")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteTodo(string id)
    {
      var todoList = _dataSource.TodoLists;
      var result = todoList.FirstOrDefault(t => t.Id == id);
      if (result == null) 
      {
        return NotFound("Data with specify id not found");
      }
      _dataSource.TodoLists.Remove(result);

      return Ok("Data removed");
    }

    public class TodoItemInputModel
    {
      public string? Title { get; set; }
      public string? Description { get; set; }
      public DateTime Deadline { get; set; }
    }
  }
}
