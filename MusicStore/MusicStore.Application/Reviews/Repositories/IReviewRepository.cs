using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Reviews;

namespace MusicStore.Application.Reviews.Repositories
{
    public interface IReviewRepository : IAddRepository<Review>, IDeleteRepository<Review>
    {
        Task<Review?> GetByIdOrDefaultAsync( Guid id );

        Task<bool> ContainsAsync( Expression<Func<Review, bool>> predicate );
    }
}
