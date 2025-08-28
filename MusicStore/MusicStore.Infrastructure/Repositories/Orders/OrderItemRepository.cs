using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Domain.Entities.Orders;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Repositories.Orders
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderItemRepository( AppDbContext dbContext )
            : base( dbContext )
        {
            _dbContext = dbContext;
        }

        public Task<OrderItem?> GetByIdOrDefaultAsync( Guid id )
        {
            return Entities.FirstOrDefaultAsync( oi => oi.Id == id );
        }
    }
}
