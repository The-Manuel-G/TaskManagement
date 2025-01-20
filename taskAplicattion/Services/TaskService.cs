using TaskManagement.DTOs;
using TaskManagement.Models;
using TaskManagement.Repositories;

namespace TaskManagement.Services
{
	public class TaskService : ITaskService
	{
		private readonly ITaskRepository _repository;

		public TaskService(ITaskRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
		{
			var tasks = await _repository.GetAllAsync();
			return tasks.Select(t => new TaskDto
			{
				Id = t.Id,
				Name = t.Name,
				Description = t.Description,
				DueDate = t.DueDate,
				StatusName = t.Status.Name
			});
		}

		public async Task<TaskDto> GetTaskByIdAsync(int id)
		{
			var task = await _repository.GetByIdAsync(id);
			if (task == null)
				throw new Exception("Task not found");

			return new TaskDto
			{
				Id = task.Id,
				Name = task.Name,
				Description = task.Description,
				DueDate = task.DueDate,
				StatusName = task.Status.Name
			};
		}

		public async Task CreateTaskAsync(CreateTaskDto dto)
		{
			var task = new TaskItem<object>
			{
				Name = dto.Name,
				Description = dto.Description,
				DueDate = dto.DueDate,
				StatusId = dto.StatusId,
				AdditionalData = null
			};

			await _repository.AddAsync(task);
		}

		public async Task UpdateTaskAsync(int id, CreateTaskDto dto)
		{
			var task = await _repository.GetByIdAsync(id);
			if (task == null)
				throw new Exception("Task not found");

			task.Name = dto.Name;
			task.Description = dto.Description;
			task.DueDate = dto.DueDate;
			task.StatusId = dto.StatusId;

			await _repository.UpdateAsync(task);
		}

		public async Task DeleteTaskAsync(int id)
		{
			var task = await _repository.GetByIdAsync(id);
			if (task == null)
				throw new Exception("Task not found");

			await _repository.DeleteAsync(id);
		}
	}
}
