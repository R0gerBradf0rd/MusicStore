using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Products.Repositories;
using MusicStore.Domain.Entities.Products;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.UnitsOfWork.Repositories.Products
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductTypeRepository( AppDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Add( ProductType entity )
        {
            _dbContext.ProductTypes.Add( entity );
        }

        public async Task<bool> ContainsAsync( Expression<Func<ProductType, bool>> predicate )
        {
            return await _dbContext.ProductTypes.AnyAsync( predicate );
        }

        public void Delete( ProductType entity )
        {
            _dbContext.ProductTypes.Remove( entity );
        }

        public async Task<ProductType?> GetByIdOrDefaultAsync( Guid id )
        {
            return await _dbContext.ProductTypes.FirstOrDefaultAsync( pt => pt.Id == id );
        }
    }
}
