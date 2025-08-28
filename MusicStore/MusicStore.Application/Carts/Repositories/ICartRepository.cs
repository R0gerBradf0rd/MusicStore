using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<Cart?> GetByIdOrDefaultAsync( Guid id );
    }
}
