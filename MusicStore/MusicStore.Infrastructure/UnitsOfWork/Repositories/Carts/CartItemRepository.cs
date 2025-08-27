using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Carts.Repositories;
using MusicStore.Domain.Entities.Carts;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.UnitsOfWork.Repositories.Carts
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly AppDbContext _dbContext;

        public CartItemRepository( AppDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Add( CartItem entity )
        {
            _dbContext.CartItems.Add( entity );
        }

        public async Task<bool> ContainsAsync( Expression<Func<CartItem, bool>> predicate )
        {
            return await _dbContext.CartItems.AnyAsync( predicate );
        }

        public void Delete( CartItem entity )
        {
            _dbContext.CartItems.Remove( entity );
        }

        public async Task<CartItem> FindAsync( Expression<Func<CartItem, bool>> predicate )
        {
            return await _dbContext.CartItems.FindAsync( predicate );
        }

        public async Task<CartItem?> GetByIdOrDefaultAsync( Guid id )
        {
            return await _dbContext.CartItems.FirstOrDefaultAsync( ci => ci.Id == id );
        }
    }
}
