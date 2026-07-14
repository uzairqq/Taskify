using Microsoft.EntityFrameworkCore;
using Taskify.Api.Models;

namespace Taskify.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
