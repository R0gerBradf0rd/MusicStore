using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Products.Repositories;
using MusicStore.Domain.Entities.Products;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Repositories.Products
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        private readonly AppDbContext _dbContext;

        public TagRepository( AppDbContext dbContext )
            : base( dbContext )
        {
            _dbContext = dbContext;
        }

        public Task<bool> ContainsAsync( Expression<Func<Tag, bool>> predicate )
        {
            return _dbContext.Tags.AnyAsync( predicate );
        }

        public Task<Tag?> GetByIdOrDefaultAsync( Guid id )
        {
            return _dbContext.Tags.FirstOrDefaultAsync( t => t.Id == id );
        }
    }
}
