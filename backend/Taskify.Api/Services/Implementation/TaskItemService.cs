using Taskify.Api.Models;
using Taskify.Api.Repositories.Interfaces;
using Taskify.Api.Services.Interfaces;

namespace Taskify.Api.Services.Implementation;

public class TaskItemService : ITaskItemService
{
    private readonly ITaskItemRepository _taskItemRepository;

    public TaskItemService(ITaskItemRepository taskItemRepository)
    {
        _taskItemRepository = taskItemRepository;
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        var existingTask=await _taskItemRepository.GetByIdAsync(id);
        if(existingTask==null)
        {
            throw new ArgumentException("Task not found.");
        }
        return existingTask;
    }
    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return await _taskItemRepository.GetAllAsync();
    }
    public async Task<TaskItem> AddAsync(TaskItem task)
    {
        if(task==null)
        {
            throw new ArgumentException("Task cannot be null.");
        }
        if(string.IsNullOrWhiteSpace(task.Title))
        {
            throw new ArgumentException("Task title cannot be empty.");
        }
        if(task.Title.Length>100)
        {
            throw new ArgumentException("Task title cannot be more than 100 characters.");
        }
        task.CreatedAt=DateTime.UtcNow;
        return await _taskItemRepository.AddAsync(task);

    }
    public async Task<TaskItem> UpdateAsync(TaskItem task)
    {
        var existingTask=await _taskItemRepository.GetByIdAsync(task.Id);
        if(existingTask==null)
        {
            throw new ArgumentException("Task not found.");
        }

        if(string.IsNullOrWhiteSpace(task.Title))
        {
            throw new ArgumentException("Task title cannot be empty.");
        }
        if(task.Title.Length>100)
        {
            throw new ArgumentException("Task title cannot be more than 100 characters.");
        }
         existingTask.Title=task.Title;
         existingTask.Description=task.Description;
         existingTask.IsCompleted=task.IsCompleted;
         existingTask.CreatedAt=task.CreatedAt;
         existingTask.UpdatedAt=DateTime.UtcNow;
        return await _taskItemRepository.UpdateAsync(existingTask);
    }
    public async Task<TaskItem?> DeleteAsync(int id)
    {
        var existingTask=await _taskItemRepository.GetByIdAsync(id);
        if(existingTask==null)
        {
            throw new ArgumentException("Task not found.");
        }
         await _taskItemRepository.DeleteAsync(id);
        return existingTask;
    }
}