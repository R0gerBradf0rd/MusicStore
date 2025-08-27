using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Orders;
using System.Linq.Expressions;

namespace MusicStore.Application.Orders.Repositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task<OrderItem?> GetByIdOrDefaultAsync( Guid id );

        Task<bool> ContainsAsync( Expression<Func<OrderItem, bool>> predicate );
    }
}
