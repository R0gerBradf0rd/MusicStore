using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Carts.Repositories;
using MusicStore.Domain.Entities.Carts;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Repositories.Carts
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly AppDbContext _dbContext;

        public CartRepository( AppDbContext dbContext )
            : base( dbContext )
        {
            _dbContext = dbContext;
        }

        public Task<Cart?> GetByIdOrDefaultAsync( Guid id )
        {
            return Entities.Include( c => c.CartItems ).
                FirstOrDefaultAsync( c => c.Id == id );
        }
    }
}
