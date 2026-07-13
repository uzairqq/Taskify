using Taskify.Api.Models;

namespace Taskify.Api.Services;

public interface ITaskItemService
{
    Task<IEnumerable<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync(int id);
    Task<TaskItem> CreateAsync(TaskItem taskItem);
    Task<TaskItem?> UpdateAsync(int id, TaskItem taskItem);
    Task<bool> DeleteAsync(int id);
}
