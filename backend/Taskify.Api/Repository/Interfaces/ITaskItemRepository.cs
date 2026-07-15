using Taskify.Api.Models;

namespace Taskify.Api.Repository.Interfaces
{
    public interface ITaskItemRepository
    {
        Task<IEnumerable<TaskItem>> GetAllTaskItemsAsync();
        Task<TaskItem?> GetTaskItemByIdAsync(int id);
        Task AddAsync(TaskItem task);
        Task UpdateAsync(int id, TaskItem task);
        Task DeleteAsync(int id);
    }
}
