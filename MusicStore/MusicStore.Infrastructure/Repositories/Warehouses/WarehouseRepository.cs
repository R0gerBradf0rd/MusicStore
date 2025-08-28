using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Warehouses.Repositories;
using MusicStore.Domain.Entities.Warehouses;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Repositories.Warehouses
{
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        private readonly AppDbContext _dbContext;

        public WarehouseRepository( AppDbContext dbContext )
            : base( dbContext )
        {
            _dbContext = dbContext;
        }

        public Task<Warehouse?> GetByIdOrDefaultAsync( Guid id )
        {
            return Entities.FirstOrDefaultAsync( w => w.Id == id );
        }
    }
}
