using TaskManagement.DTOs;

namespace TaskManagement.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllTasksAsync();
        Task<TaskDto> GetTaskByIdAsync(int id);
        Task CreateTaskAsync(CreateTaskDto dto);
        Task UpdateTaskAsync(int id, CreateTaskDto dto);
        Task DeleteTaskAsync(int id);
    }
}
