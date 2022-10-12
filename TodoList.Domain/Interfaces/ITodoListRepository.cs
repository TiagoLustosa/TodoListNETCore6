using TodoList.Domain.Entities;

namespace TodoList.Domain.Interfaces
{
    public interface ITodoListRepository
    {
        Task<Todo> GetTodoById(Guid id);
        Task<IEnumerable<Todo>> GetAllTodos();
        Task<Todo> AddTodo(Todo todo);
        Task UpdateTodo(Todo todo);
        Task RemoveTodo(Todo todo);
    }
}
