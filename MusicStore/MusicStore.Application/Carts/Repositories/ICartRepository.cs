using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Repositories
{
    public interface ICartRepository : IAddRepository<Cart>, IDeleteRepository<Cart>
    {
        Task<Cart?> GetByIdOrDefaultAsync( Guid id );

        Task<bool> ContainsAsync( Expression<Func<Cart, bool>> predicate );
    }
}
