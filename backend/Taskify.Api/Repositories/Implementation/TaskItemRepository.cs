
using Microsoft.EntityFrameworkCore;
using Taskify.Api.Data;
using Taskify.Api.Models;
using Taskify.Api.Repositories.Interfaces;

namespace Taskify.Api.Repositories.Implementation;

public class TaskItemRepository : ITaskItemRepository
{
    private readonly ApplicationDbContext _context;
    public TaskItemRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        return await _context.TaskItems.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
    }
    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return await _context.TaskItems.AsNoTracking().ToListAsync();
    }
    public async Task<TaskItem> AddAsync(TaskItem task)
    {
        _context.TaskItems.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }
    public async Task<TaskItem> UpdateAsync(TaskItem task)
    {
        _context.TaskItems.Update(task);
        await _context.SaveChangesAsync();
        return task;
    }
    public async Task<TaskItem?> DeleteAsync(int id)
    {
        var task = await _context.TaskItems.FindAsync(id);
        if(task!=null)
        {
            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();
        }
        return task;
    }
}