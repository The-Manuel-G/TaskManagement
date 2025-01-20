using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Models;

namespace TaskManagement.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem<object>>> GetAllAsync()
        {
            return await _context.TaskItems.Include(t => t.Status).ToListAsync();
        }

        public async Task<TaskItem<object>> GetByIdAsync(int id)
        {
            return await _context.TaskItems.Include(t => t.Status).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(TaskItem<object> task)
        {
            await _context.TaskItems.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskItem<object> task)
        {
            _context.TaskItems.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await GetByIdAsync(id);
            if (task != null)
            {
                _context.TaskItems.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
