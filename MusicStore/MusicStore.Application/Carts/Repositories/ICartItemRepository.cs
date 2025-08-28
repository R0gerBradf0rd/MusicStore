using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Repositories
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        Task<CartItem?> FindAsync( Expression<Func<CartItem, bool>> predicate );

        Task<CartItem?> GetByIdOrDefaultAsync( Guid id );
    }
}
