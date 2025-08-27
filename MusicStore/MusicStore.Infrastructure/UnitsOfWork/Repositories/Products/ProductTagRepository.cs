using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Products.Repositories;
using MusicStore.Domain.Entities.Products;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.UnitsOfWork.Repositories.Products
{
    public class ProductTagRepository : IProductTagRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductTagRepository( AppDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Add( ProductTag entity )
        {
            _dbContext.ProductTags.Add( entity );
        }

        public async Task<bool> ContainsAsync( Expression<Func<ProductTag, bool>> predicate )
        {
            return await _dbContext.ProductTags.AnyAsync( predicate );
        }

        public void Delete( ProductTag entity )
        {
            _dbContext.ProductTags.Remove( entity );
        }

        public async Task<ProductTag> FindAsync( Expression<Func<ProductTag, bool>> predicate )
        {
            return await _dbContext.ProductTags.FindAsync( predicate );
        }
    }
}
