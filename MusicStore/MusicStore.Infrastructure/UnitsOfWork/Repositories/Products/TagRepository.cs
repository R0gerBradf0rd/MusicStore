using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Products.Repositories;
using MusicStore.Domain.Entities.Products;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.UnitsOfWork.Repositories.Products
{
    public class TagRepository : ITagRepository
    {
        private readonly AppDbContext _dbContext;

        public TagRepository( AppDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Add( Tag entity )
        {
            _dbContext.Tags.Add( entity );
        }

        public async Task<bool> ContainsAsync( Expression<Func<Tag, bool>> predicate )
        {
            return await _dbContext.Tags.AnyAsync( predicate );
        }

        public void Delete( Tag entity )
        {
            _dbContext.Tags.Remove( entity );
        }

        public async Task<Tag?> GetByIdOrDefaultAsync( Guid id )
        {
            return await _dbContext.Tags.FirstOrDefaultAsync( t => t.Id == id );
        }
    }
}
