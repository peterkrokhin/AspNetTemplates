using Microsoft.EntityFrameworkCore;

namespace TodoApiWithMediatr.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    }
}