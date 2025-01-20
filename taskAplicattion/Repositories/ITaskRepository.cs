using TaskManagement.Models;

namespace TaskManagement.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem<object>>> GetAllAsync();
        Task<TaskItem<object>> GetByIdAsync(int id);
        Task AddAsync(TaskItem<object> task);
        Task UpdateAsync(TaskItem<object> task);
        Task DeleteAsync(int id);
    }
    }
