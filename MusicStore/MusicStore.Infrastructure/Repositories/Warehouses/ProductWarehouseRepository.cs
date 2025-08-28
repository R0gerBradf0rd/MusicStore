using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Warehouses.Repositories;
using MusicStore.Domain.Entities.Warehouses;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Repositories.Warehouses
{
    public class ProductWarehouseRepository : Repository<ProductWarehouse>, IProductWarehouseRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductWarehouseRepository( AppDbContext dbContext )
            : base( dbContext )
        {
            _dbContext = dbContext;
        }

        public Task<ProductWarehouse?> FindAsync( Expression<Func<ProductWarehouse, bool>> predicate )
        {
            return Entities.FirstOrDefaultAsync( predicate );
        }
    }
}
