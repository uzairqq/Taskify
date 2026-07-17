using Taskify.Api.Models;

namespace Taskify.Api.Repositories.Interfaces;

public interface ITaskItemRepository
{
    Task<TaskItem?> GetByIdAsync(int id);
    Task<IEnumerable<TaskItem>> GetAllAsync();
    Task<TaskItem> AddAsync(TaskItem task);
    Task<TaskItem> UpdateAsync(TaskItem task);
    Task<TaskItem?> DeleteAsync(int id);
}