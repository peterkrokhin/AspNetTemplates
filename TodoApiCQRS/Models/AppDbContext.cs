using Microsoft.EntityFrameworkCore;

namespace TodoApiCQRS.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    }
}