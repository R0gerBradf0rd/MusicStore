using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Products.Repositories;
using MusicStore.Domain.Entities.Products;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.UnitsOfWork.Repositories.Products
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository( AppDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Add( Category entity )
        {
            _dbContext.Categories.Add( entity );
        }

        public async Task<bool> ContainsAsync( Expression<Func<Category, bool>> predicate )
        {
            return await _dbContext.Categories.AnyAsync( predicate );
        }

        public void Delete( Category entity )
        {
            _dbContext.Categories.Remove( entity );
        }

        public async Task<Category?> GetByIdOrDefaultAsync( Guid id )
        {
            return await _dbContext.Categories.FirstOrDefaultAsync( c => c.Id == id );
        }
    }
}
