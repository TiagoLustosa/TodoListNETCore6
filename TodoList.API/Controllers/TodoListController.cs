using Microsoft.AspNetCore.Mvc;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.API.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListService _todoListService;
        private readonly ITodoListRepository _todoListRepository;
        public TodoListController(ITodoListService todoListService, ITodoListRepository todoListRepository)
        {
            _todoListService = todoListService;
            _todoListRepository = todoListRepository;
        }
        [HttpGet("getAllTodos")]
        public async Task<IActionResult> GetAllTodos()
        {
            return Ok(await _todoListRepository.GetAllTodos());
        }
        [HttpGet("getTodoById/{id}")]
        public async Task<IActionResult> GetTodoById(Guid id)
        {
            return Ok(await _todoListRepository.GetTodoById(id));
        }
        [HttpPost("AddTodo")]
        public async Task<IActionResult> AddTodo(Todo todo)
        {
            return Ok(await _todoListRepository.AddTodo(todo));
        }
        [HttpPut("updateTodo/{id}")]
        public async Task<IActionResult> UpdateTodo(Guid id, Todo todo)
        {

            return Ok(await _todoListService.UpdateTodo(id, todo));
        }
        [HttpDelete("deletetodo/{id}")]
        public async Task<IActionResult> RemoveTodo(Guid id)
        {
            await _todoListService.RemoveTodo(id);
            return Ok();
        }
    }
}
