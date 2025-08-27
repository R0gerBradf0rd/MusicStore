using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Domain.Entities.Orders;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.UnitsOfWork.Repositories.Orders
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderItemRepository( AppDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Add( OrderItem entity )
        {
            _dbContext.OrderItems.Add( entity );
        }

        public async Task<bool> ContainsAsync( Expression<Func<OrderItem, bool>> predicate )
        {
            return await _dbContext.OrderItems.AnyAsync( predicate );
        }

        public void Delete( OrderItem entity )
        {
            _dbContext.OrderItems.Remove( entity );
        }

        public async Task<OrderItem?> GetByIdOrDefaultAsync( Guid id )
        {
            return await _dbContext.OrderItems.FirstOrDefaultAsync( oi => oi.Id == id );
        }
    }
}
