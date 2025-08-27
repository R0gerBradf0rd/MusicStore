using System.Linq.Expressions;
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

        public Task<bool> ContainsAsync( Expression<Func<OrderItem, bool>> predicate )
        {
            return _dbContext.OrderItems.AnyAsync( predicate );
        }

        public Task<OrderItem?> GetByIdOrDefaultAsync( Guid id )
        {
            return _dbContext.OrderItems.FirstOrDefaultAsync( oi => oi.Id == id );
        }
    }
}
