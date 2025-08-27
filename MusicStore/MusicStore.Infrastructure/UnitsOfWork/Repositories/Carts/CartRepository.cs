using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Carts.Repositories;
using MusicStore.Domain.Entities.Carts;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.UnitsOfWork.Repositories.Carts
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _dbContext;

        public CartRepository( AppDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Add( Cart entity )
        {
            _dbContext.Carts.Add( entity );
        }

        public async Task<bool> ContainsAsync( Expression<Func<Cart, bool>> predicate )
        {
            return await _dbContext.Carts.AnyAsync( predicate );
        }

        public void Delete( Cart entity )
        {
            _dbContext.Carts.Remove( entity );
        }

        public async Task<Cart?> GetByIdOrDefaultAsync( Guid id )
        {
            return await _dbContext.Carts.FirstOrDefaultAsync( c => c.Id == id );
        }
    }
}
