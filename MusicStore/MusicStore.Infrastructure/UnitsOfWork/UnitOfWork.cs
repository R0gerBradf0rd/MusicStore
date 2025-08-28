using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork( AppDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
