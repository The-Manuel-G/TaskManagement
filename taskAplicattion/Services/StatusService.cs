using TaskManagement.Models;
using TaskManagement.Repositories;

namespace TaskManagement.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _repository;

        public StatusService(IStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Status>> GetAllStatusesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Status> GetStatusByIdAsync(int id)
        {
            var status = await _repository.GetByIdAsync(id);
            if (status == null)
                throw new Exception("Status not found");

            return status;
        }

        public async Task CreateStatusAsync(Status status)
        {
            await _repository.AddAsync(status);
        }

        public async Task UpdateStatusAsync(Status status)
        {
            await _repository.UpdateAsync(status);
        }

        public async Task DeleteStatusAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
