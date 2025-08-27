using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Domain.Entities.Orders;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Repositories.Orders
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository( AppDbContext dbContext )
            : base( dbContext )
        {
            _dbContext = dbContext;
        }

        public Task<bool> ContainsAsync( Expression<Func<Order, bool>> predicate )
        {
            return _dbContext.Orders.AnyAsync( predicate );
        }

        public Task<Order?> GetByIdOrDefaultAsync( Guid id )
        {
            return _dbContext.Orders.FirstOrDefaultAsync( o => o.Id == id );
        }
    }
}
