using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Carts.Repositories;
using MusicStore.Domain.Entities.Carts;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Repositories.Carts
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        private readonly AppDbContext _dbContext;

        public CartItemRepository( AppDbContext dbContext )
            : base( dbContext )
        {
            _dbContext = dbContext;
        }

        public Task<bool> ContainsAsync( Expression<Func<CartItem, bool>> predicate )
        {
            return _dbContext.CartItems.AnyAsync( predicate );
        }

        public Task<CartItem?> FindAsync( Expression<Func<CartItem, bool>> predicate )
        {
            return _dbContext.CartItems.FirstOrDefaultAsync( predicate );
        }

        public Task<CartItem?> GetByIdOrDefaultAsync( Guid id )
        {
            return _dbContext.CartItems.FirstOrDefaultAsync( ci => ci.Id == id );
        }
    }
}
