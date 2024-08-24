using sample_api.Models;
using Microsoft.EntityFrameworkCore;

namespace sample_api.Entities
{
    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
            : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();

    }
}
