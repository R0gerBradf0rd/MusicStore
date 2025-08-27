using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Warehouses.Repositories;
using MusicStore.Domain.Entities.Warehouses;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.UnitsOfWork.Repositories.Warehouses
{
    public class ProductWarehouseRepository : IProductWarehouseRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductWarehouseRepository( AppDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Add( ProductWarehouse entity )
        {
            _dbContext.ProductWarehouses.Add( entity );
        }

        public async Task<bool> ContainsAsync( Expression<Func<ProductWarehouse, bool>> predicate )
        {
            return await _dbContext.ProductWarehouses.AnyAsync( predicate );
        }

        public void Delete( ProductWarehouse entity )
        {
            _dbContext.ProductWarehouses.Remove( entity );
        }

        public async Task<ProductWarehouse> FindAsync( Expression<Func<ProductWarehouse, bool>> predicate )
        {
            return await _dbContext.ProductWarehouses.FindAsync( predicate );
        }
    }
}
