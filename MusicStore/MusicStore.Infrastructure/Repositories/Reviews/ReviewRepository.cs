using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Reviews.Repositories;
using MusicStore.Domain.Entities.Reviews;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Repositories.Reviews
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private readonly AppDbContext _dbContext;

        public ReviewRepository( AppDbContext dbContext )
            : base( dbContext )
        {
            _dbContext = dbContext;
        }

        public Task<bool> ContainsAsync( Expression<Func<Review, bool>> predicate )
        {
            return _dbContext.Reviews.AnyAsync( predicate );
        }

        public Task<Review?> GetByIdOrDefaultAsync( Guid id )
        {
            return _dbContext.Reviews.FirstOrDefaultAsync( r => r.Id == id );
        }
    }
}
