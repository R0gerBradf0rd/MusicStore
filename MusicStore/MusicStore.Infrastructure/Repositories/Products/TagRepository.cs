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

        public Task<Tag?> GetByIdOrDefaultAsync( Guid id )
        {
            return Entities.FirstOrDefaultAsync( t => t.Id == id );
        }
    }
}
