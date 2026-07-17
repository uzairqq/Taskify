using Taskify.Api.Models;

namespace Taskify.Api.Services.Interfaces;

public interface ITaskItemService
{
    Task<TaskItem?> GetByIdAsync(int id);
    Task<IEnumerable<TaskItem>> GetAllAsync();
    Task<TaskItem> AddAsync(TaskItem task);
    Task<TaskItem> UpdateAsync(TaskItem task);
    Task<TaskItem?> DeleteAsync(int id);
}