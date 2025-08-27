using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Products.Repositories;
using MusicStore.Domain.Entities.Products;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Repositories.Products
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductTypeRepository( AppDbContext dbContext )
            : base( dbContext )
        {
            _dbContext = dbContext;
        }

        public Task<bool> ContainsAsync( Expression<Func<ProductType, bool>> predicate )
        {
            return _dbContext.ProductTypes.AnyAsync( predicate );
        }

        public Task<ProductType?> GetByIdOrDefaultAsync( Guid id )
        {
            return _dbContext.ProductTypes.FirstOrDefaultAsync( pt => pt.Id == id );
        }
    }
}
