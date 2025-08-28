using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Repositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task<OrderItem?> GetByIdOrDefaultAsync( Guid id );
    }
}
