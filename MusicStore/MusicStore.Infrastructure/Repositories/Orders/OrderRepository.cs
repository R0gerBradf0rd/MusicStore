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

        public Task<Order?> GetByIdOrDefaultAsync( Guid id )
        {
            return Entities.FirstOrDefaultAsync( o => o.Id == id );
        }
    }
}
