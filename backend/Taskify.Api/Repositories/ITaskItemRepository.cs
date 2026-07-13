using Taskify.Api.Models;

namespace Taskify.Api.Repositories;

public interface ITaskItemRepository
{
    Task<IEnumerable<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync(int id);
    Task<TaskItem> CreateAsync(TaskItem taskItem);
    Task<TaskItem?> UpdateAsync(TaskItem taskItem);
    Task<bool> DeleteAsync(int id);
}
