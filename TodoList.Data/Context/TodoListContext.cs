using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using TodoList.Domain.Entities;

namespace TodoList.Infra.Context
{
    public class TodoListContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public TodoListContext(DbContextOptions<TodoListContext> options, IConfiguration configuration)
                                                          : base(options)
        {
            Configuration = configuration;
        }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }
    }
}
