using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Repositories
{
    public interface ICartItemRepository : IAddRepository<CartItem>, IDeleteRepository<CartItem>
    {
        Task<bool> ContainsAsync( Expression<Func<CartItem, bool>> predicate );

        Task<CartItem> FindeAsync( Expression<Func<CartItem, bool>> predicate );

        Task<CartItem?> GetByIdOrDefaultAsync( Guid id );
    }
}
