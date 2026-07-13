using Microsoft.AspNetCore.Mvc;
using Taskify.Api.Models;
using Taskify.Api.Services;

namespace Taskify.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskItemController : ControllerBase
{
    private readonly ITaskItemService _taskItemService;

    public TaskItemController(ITaskItemService taskItemService)
    {
        _taskItemService = taskItemService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetAll()
    {
        var taskItems = await _taskItemService.GetAllAsync();
        return Ok(taskItems);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TaskItem>> GetById(int id)
    {
        var taskItem = await _taskItemService.GetByIdAsync(id);
        if (taskItem is null)
        {
            return NotFound();
        }

        return Ok(taskItem);
    }

    [HttpPost]
    public async Task<ActionResult<TaskItem>> Create(TaskItem taskItem)
    {
        var createdTaskItem = await _taskItemService.CreateAsync(taskItem);
        return CreatedAtAction(nameof(GetById), new { id = createdTaskItem.Id }, createdTaskItem);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<TaskItem>> Update(int id, TaskItem taskItem)
    {
        var updatedTaskItem = await _taskItemService.UpdateAsync(id, taskItem);
        if (updatedTaskItem is null)
        {
            return NotFound();
        }

        return Ok(updatedTaskItem);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _taskItemService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
