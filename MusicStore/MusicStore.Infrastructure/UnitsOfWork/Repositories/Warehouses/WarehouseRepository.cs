using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Warehouses.Repositories;
using MusicStore.Domain.Entities.Warehouses;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.UnitsOfWork.Repositories.Warehouses
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly AppDbContext _dbContext;

        public WarehouseRepository( AppDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Add( Warehouse entity )
        {
            _dbContext.Warehouses.Add( entity );
        }

        public async Task<bool> ContainsAsync( Expression<Func<Warehouse, bool>> predicate )
        {
            return await _dbContext.Warehouses.AnyAsync( predicate );
        }

        public void Delete( Warehouse entity )
        {
            _dbContext.Warehouses.Remove( entity );
        }

        public async Task<Warehouse?> GetByIdOrDefaultAsync( Guid id )
        {
            return await _dbContext.Warehouses.FirstOrDefaultAsync( w => w.Id == id );
        }
    }
}
