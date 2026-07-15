using Taskify.Api.Models;
using Taskify.Api.Repository.Interfaces;
using Taskify.Api.Services.Interfaces;

namespace Taskify.Api.Services.Implementation
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public TaskItemService(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTaskItemsAsync()
        {
            return await _taskItemRepository.GetAllTaskItemsAsync();
        }

        public async Task<TaskItem?> GetTaskItemByIdAsync(int id)
        {
            return await _taskItemRepository.GetTaskItemByIdAsync(id);
        }

        public async Task AddTaskItemAsync(TaskItem taskItem)
        {
            taskItem.CreatedAt = DateTime.UtcNow;
            await _taskItemRepository.AddAsync(taskItem);
        }

        public async Task UpdateTaskItemAsync(int id, TaskItem taskItem)
        {
            await _taskItemRepository.UpdateAsync(id, taskItem);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _taskItemRepository.DeleteAsync(id);
        }


    }
}
