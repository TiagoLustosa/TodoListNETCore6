using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;

namespace TodoList.Infra.Context
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options)
                                                          : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
    }
}
