using System.Linq.Expressions;
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

        public Task<bool> ContainsAsync( Expression<Func<Warehouse, bool>> predicate )
        {
            return _dbContext.Warehouses.AnyAsync( predicate );
        }

        public Task<Warehouse?> GetByIdOrDefaultAsync( Guid id )
        {
            return _dbContext.Warehouses.FirstOrDefaultAsync( w => w.Id == id );
        }
    }
}
