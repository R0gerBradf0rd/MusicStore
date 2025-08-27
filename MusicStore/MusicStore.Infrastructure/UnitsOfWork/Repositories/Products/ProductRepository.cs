using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Products.Repositories;
using MusicStore.Domain.Entities.Products;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.UnitsOfWork.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository( AppDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Add( Product entity )
        {
            _dbContext.Products.Add( entity );
        }

        public async Task<bool> ContainsAsync( Expression<Func<Product, bool>> predicate )
        {
            return await _dbContext.Products.AnyAsync( predicate );
        }

        public void Delete( Product entity )
        {
            _dbContext.Products.Remove( entity );
        }

        public async Task<Product?> GetByIdOrDefaultAsync( Guid id )
        {
            return await _dbContext.Products.FirstOrDefaultAsync( p => p.Id == id );
        }
    }
}
