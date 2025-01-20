using TaskManagement.Models;


namespace TaskManagement.Repositories
{
    public interface IStatusRepository
    {

        Task<IEnumerable<Status>> GetAllAsync();
        Task<Status> GetAsync(int id);
        Task AddAsync(Status status);
        Task UpdateAsync(Status status);
        Task DeleteAsync(int id);
        Task<Status> GetByIdAsync(int id);
    }
}
