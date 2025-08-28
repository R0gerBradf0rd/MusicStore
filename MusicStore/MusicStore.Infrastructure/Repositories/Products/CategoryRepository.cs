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

        public Task<Category?> GetByIdOrDefaultAsync( Guid id )
        {
            return Entities.FirstOrDefaultAsync( c => c.Id == id );
        }
    }
}
