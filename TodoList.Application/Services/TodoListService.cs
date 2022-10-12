using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ITodoListRepository _todoListRepository;
        public TodoListService(ITodoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }
        public async Task RemoveTodo(Guid id)
        {
            var todo = await _todoListRepository.GetTodoById(id);
            await _todoListRepository.RemoveTodo(todo);
        }

        public async Task<Todo> UpdateTodo(Guid id, Todo todo)
        {
            var todoFromRepository = await _todoListRepository.GetTodoById(id);     
            todoFromRepository.Title = todo.Title;
            todoFromRepository.Description = todo.Description;
            todoFromRepository.EndDate = todo.EndDate;

            await _todoListRepository.UpdateTodo(todoFromRepository);

            return todoFromRepository;
        }
    }
}
