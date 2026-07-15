using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskify.Api.Models;
using Taskify.Api.Services.Interfaces;

namespace Taskify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;

        public TaskItemController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskItemService.GetAllTaskItemsAsync();
            return Ok(tasks);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskItemService.GetTaskItemByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskItem task)
        {
            await _taskItemService.AddTaskItemAsync(task);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskItem task)
        {
            await _taskItemService.UpdateTaskItemAsync(id, task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskItemService.DeleteTaskAsync(id);
            return NoContent();
        }



    }
}
