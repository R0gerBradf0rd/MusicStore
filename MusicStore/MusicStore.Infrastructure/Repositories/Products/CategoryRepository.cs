using System.Linq.Expressions;
using Microsoft.Azure.Pipelines.WebApi;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Products.Repositories;
using MusicStore.Domain.Entities.Products;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Repositories.Products
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository( AppDbContext dbContext )
            : base( dbContext )
        {
            _dbContext = dbContext;
        }

        public Task<bool> ContainsAsync( Expression<Func<Category, bool>> predicate )
        {
            return _dbContext.Categories.AnyAsync( predicate );
        }

        public Task<Category?> GetByIdOrDefaultAsync( Guid id )
        {
            return _dbContext.Categories.FirstOrDefaultAsync( c => c.Id == id );
        }
    }
}
