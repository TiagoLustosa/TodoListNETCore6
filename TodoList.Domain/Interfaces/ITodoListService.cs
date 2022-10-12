using TodoList.Domain.Entities;

namespace TodoList.Domain.Interfaces
{
    public interface ITodoListService
    {
        Task RemoveTodo(Guid id);

        Task<Todo> UpdateTodo(Guid id, Todo todo);
    }
}
