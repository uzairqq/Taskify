using Taskify.Api.Models;

namespace Taskify.Api.Services.Interfaces
{
    public interface ITaskItemService
    {
        Task AddTaskItemAsync(TaskItem taskItem);
        Task DeleteTaskAsync(int id);
        Task<IEnumerable<TaskItem>> GetAllTaskItemsAsync();
        Task<TaskItem?> GetTaskItemByIdAsync(int id);
        Task UpdateTaskItemAsync(int id, TaskItem taskItem);
    }
}
