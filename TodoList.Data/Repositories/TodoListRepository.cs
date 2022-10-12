using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;
using TodoList.Infra.Context;

namespace TodoList.Infra.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly TodoListContext _context;
        public TodoListRepository(TodoListContext context)
        {
            _context = context;
        }
        public async Task<Todo> AddTodo(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task RemoveTodo(Todo todo)
        {
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }

        public async Task<Todo> GetTodoById(Guid id)
        {
            return await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateTodo(Todo todo)
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await _context.Todos.OrderByDescending(x => x.EndDate).ToListAsync();
        }
    }
}
