using Microsoft.EntityFrameworkCore;
using Taskify.Api.Data;
using Taskify.Api.Models;
using Taskify.Api.Repository.Interfaces;

namespace Taskify.Api.Repository.Implementation
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TaskItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TaskItem task)
        {
            await _dbContext.TaskItems.AddAsync(task);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _dbContext.TaskItems.FindAsync(id);
            if (task != null)
            {
                _dbContext.TaskItems.Remove(task);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task<IEnumerable<TaskItem>> GetAllTaskItemsAsync()
        {
            return await _dbContext.TaskItems.ToListAsync();
        }

        public async Task<TaskItem?> GetTaskItemByIdAsync(int id)
        {
            return await _dbContext.TaskItems.FindAsync(id);
        }

        public async Task UpdateAsync(int id, TaskItem task)
        {
            var existing = await _dbContext.TaskItems.FindAsync(id);
            if (existing != null)
            {
                existing.Title = task.Title;
                existing.Description = task.Description;
                existing.IsCompleted = task.IsCompleted;
                existing.DueDate = task.DueDate;
                existing.Priority = task.Priority;
                existing.UpdateAt = DateTime.UtcNow;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
