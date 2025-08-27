using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Reviews.Repositories;
using MusicStore.Domain.Entities.Reviews;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.UnitsOfWork.Repositories.Reviews
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _dbContext;

        public ReviewRepository( AppDbContext dbContext )
        {
            _dbContext = dbContext;
        }
        public void Add( Review entity )
        {
            _dbContext.Reviews.Add( entity );
        }

        public async Task<bool> ContainsAsync( Expression<Func<Review, bool>> predicate )
        {
            return await _dbContext.Reviews.AnyAsync( predicate );
        }

        public void Delete( Review entity )
        {
            _dbContext.Reviews.Remove( entity );
        }

        public async Task<Review?> GetByIdOrDefaultAsync( Guid id )
        {
            return await _dbContext.Reviews.FirstOrDefaultAsync( r => r.Id == id );
        }
    }
}
