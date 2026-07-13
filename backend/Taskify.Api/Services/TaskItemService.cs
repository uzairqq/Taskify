using Taskify.Api.Models;
using Taskify.Api.Repositories;

namespace Taskify.Api.Services;

public class TaskItemService : ITaskItemService
{
    private readonly ITaskItemRepository _repository;

    public TaskItemService(ITaskItemRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<TaskItem?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public async Task<TaskItem> CreateAsync(TaskItem taskItem)
    {
        taskItem.CreatedAt = DateTime.UtcNow;
        taskItem.UpdatedAt = null;

        return await _repository.CreateAsync(taskItem);
    }

    public async Task<TaskItem?> UpdateAsync(int id, TaskItem taskItem)
    {
        var existingTaskItem = await _repository.GetByIdAsync(id);
        if (existingTaskItem is null)
        {
            return null;
        }

        taskItem.Id = id;
        taskItem.CreatedAt = existingTaskItem.CreatedAt;
        taskItem.UpdatedAt = DateTime.UtcNow;

        return await _repository.UpdateAsync(taskItem);
    }

    public Task<bool> DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }
}
