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

        public Task<CartItem?> FindAsync( Expression<Func<CartItem, bool>> predicate )
        {
            return Entities.FirstOrDefaultAsync( predicate );
        }

        public Task<CartItem?> GetByIdOrDefaultAsync( Guid id )
        {
            return Entities.FirstOrDefaultAsync( ci => ci.Id == id );
        }
    }
}
