

    using Microsoft.EntityFrameworkCore;
    using TaskManagement.Data;
    using TaskManagement.Models;

    namespace TaskManagement.Repositories
    {
        public class StatusRepository : IStatusRepository
        {
            private readonly AppDbContext _context;

            public StatusRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Status>> GetAllAsync()
            {
                return await _context.Statuses.ToListAsync();
            }

            public async Task<Status> GetByIdAsync(int id)
            {
                return await _context.Statuses.FindAsync(id);
            }

            public async Task AddAsync(Status status)
            {
                await _context.Statuses.AddAsync(status);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateAsync(Status status)
            {
                _context.Statuses.Update(status);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var status = await GetByIdAsync(id);
                if (status != null)
                {
                    _context.Statuses.Remove(status);
                    await _context.SaveChangesAsync();
                }
            }

        public Task<Status> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
    }

