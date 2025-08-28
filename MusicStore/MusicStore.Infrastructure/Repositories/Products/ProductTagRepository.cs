using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Products.Repositories;
using MusicStore.Domain.Entities.Products;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Repositories.Products
{
    public class ProductTagRepository : Repository<ProductTag>, IProductTagRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductTagRepository( AppDbContext dbContext )
            : base( dbContext )
        {
            _dbContext = dbContext;
        }

        public Task<ProductTag?> FindAsync( Expression<Func<ProductTag, bool>> predicate )
        {
            return Entities.FirstOrDefaultAsync( predicate );
        }
    }
}
