using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Models;

namespace Todo.Api.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class TodoController : Controller
  {
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetTodoLists()
    {
      var todoList = this.GetListOfTodoItems();
      return Ok(todoList);
    }

    [HttpPost]
    public IActionResult CreateTodoItem([FromBody] TodoItemInputModel input)
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

      return Ok(todoItem);
    }

    private List<TodoItem> GetListOfTodoItems()
    {
      return new List<TodoItem>
      {
        new TodoItem
        {
          Title = "Membuat todo list",
          Description = "Memuat todo list untuk latihan C# pertama",
          Deadline = DateTime.Now.AddHours(2),
        },
        new TodoItem
        {
          Title = "Membuat expense tracker",
          Description = "Membuat expense tracker dengan DDD",
          Deadline = DateTime.Now.AddDays(2),
        }
      };
    }

    public class TodoItemInputModel
    {
      public string? Title { get; set; }
      public string? Description { get; set; }
      public DateTime Deadline { get; set; }
    }
  }
}
