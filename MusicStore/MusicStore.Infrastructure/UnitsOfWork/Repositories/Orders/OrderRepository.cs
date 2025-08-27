using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Domain.Entities.Orders;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.UnitsOfWork.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository( AppDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Add( Order entity )
        {
            _dbContext.Orders.Add( entity );
        }

        public async Task<bool> ContainsAsync( Expression<Func<Order, bool>> predicate )
        {
            return await _dbContext.Orders.AnyAsync( predicate );
        }

        public void Delete( Order entity )
        {
            _dbContext.Orders.Remove( entity );
        }

        public async Task<Order?> GetByIdOrDefaultAsync( Guid id )
        {
            return await _dbContext.Orders.FirstOrDefaultAsync( o => o.Id == id );
        }
    }
}
