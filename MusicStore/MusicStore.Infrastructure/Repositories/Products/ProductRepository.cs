using System.Linq.Expressions;
using Microsoft.Azure.Pipelines.WebApi;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Products.Repositories;
using MusicStore.Domain.Entities.Products;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Repositories.Products
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository( AppDbContext dbContext )
            : base( dbContext )
        {
            _dbContext = dbContext;
        }

        public Task<bool> ContainsAsync( Expression<Func<Product, bool>> predicate )
        {
            return _dbContext.Products.AnyAsync( predicate );
        }

        public Task<Product?> GetByIdOrDefaultAsync( Guid id )
        {
            return _dbContext.Products.FirstOrDefaultAsync( p => p.Id == id );
        }
    }
}
