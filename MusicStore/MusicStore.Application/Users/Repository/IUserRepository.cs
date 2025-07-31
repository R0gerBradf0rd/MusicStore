using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Users.Repository
{
    public interface IUserRepository : IAddRepository<User>, IDeleteRepository<User>
    {
        Task<User?> GetByIdAsync( Guid id );

        Task<bool> ContainsAsync( Expression<Func<User, bool>> predicate );
    }
}
