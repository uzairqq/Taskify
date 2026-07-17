using Microsoft.AspNetCore.Mvc;
using Taskify.Api.Models;
using Taskify.Api.Services.Interfaces;

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
        var tasks = await _taskItemService.GetAllAsync();
        return Ok(tasks);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> GetById(int id)
    {
        var task = await _taskItemService.GetByIdAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }
    
    [HttpPost]
    public async Task<ActionResult<TaskItem>> Add([FromBody] TaskItem task)
    {
        var createdTask = await _taskItemService.AddAsync(task);
        return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, createdTask);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<TaskItem>> Update(int id, [FromBody] TaskItem task)
    {
        if (id != task.Id)
        {
            return BadRequest();
        }
        try
        {
            var updatedTask = await _taskItemService.UpdateAsync(task);
            return Ok(updatedTask);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<TaskItem>> Delete(int id)
    {
        try
        {
            var deletedTask = await _taskItemService.DeleteAsync(id);
            return Ok(deletedTask);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }
}
