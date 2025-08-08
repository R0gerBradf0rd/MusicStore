using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Users.Repositories
{
    public interface IUserRepository : IAddRepository<User>, IDeleteRepository<User>
    {
        Task<User?> GetByIdOrDefaultAsync( Guid id );

        Task<bool> ContainsAsync( Expression<Func<User, bool>> predicate );
    }
}
