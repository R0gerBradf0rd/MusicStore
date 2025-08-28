using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Users.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByIdOrDefaultAsync( Guid id );
    }
}
