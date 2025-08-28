using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order?> GetByIdOrDefaultAsync( Guid id );
    }
}
