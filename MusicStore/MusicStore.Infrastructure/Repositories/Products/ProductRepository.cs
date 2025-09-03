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

        public Task<Product?> GetByIdOrDefaultAsync( Guid id )
        {
            return Entities.Include( p => p.ProductTags )
                .FirstOrDefaultAsync( p => p.Id == id );
        }
    }
}
