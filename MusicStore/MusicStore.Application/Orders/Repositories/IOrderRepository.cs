using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Repositories
{
    public interface IOrderRepository : IAddRepository<Order>, IDeleteRepository<Order>
    {
        Task<Order?> GetByIdOrDefaultAsync( Guid id );

        Task<bool> ContainsAsync( Expression<Func<Order, bool>> predicate );
    }
}
