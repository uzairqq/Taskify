using Microsoft.EntityFrameworkCore;
using Taskify.Api.Data;
using Taskify.Api.Models;

namespace Taskify.Api.Repositories;

public class TaskItemRepository : ITaskItemRepository
{
    private readonly AppDbContext _context;

    public TaskItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return await _context.TaskItems.ToListAsync();
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        return await _context.TaskItems.FindAsync(id);
    }

    public async Task<TaskItem> CreateAsync(TaskItem taskItem)
    {
        _context.TaskItems.Add(taskItem);
        await _context.SaveChangesAsync();
        return taskItem;
    }

    public async Task<TaskItem?> UpdateAsync(TaskItem taskItem)
    {
        var existingTaskItem = await _context.TaskItems.FindAsync(taskItem.Id);
        if (existingTaskItem is null)
        {
            return null;
        }

        existingTaskItem.Title = taskItem.Title;
        existingTaskItem.Description = taskItem.Description;
        existingTaskItem.IsCompleted = taskItem.IsCompleted;
        existingTaskItem.DueDate = taskItem.DueDate;
        existingTaskItem.Priority = taskItem.Priority;
        existingTaskItem.UpdatedAt = taskItem.UpdatedAt;

        await _context.SaveChangesAsync();
        return existingTaskItem;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var taskItem = await _context.TaskItems.FindAsync(id);
        if (taskItem is null)
        {
            return false;
        }

        _context.TaskItems.Remove(taskItem);
        await _context.SaveChangesAsync();
        return true;
    }
}
