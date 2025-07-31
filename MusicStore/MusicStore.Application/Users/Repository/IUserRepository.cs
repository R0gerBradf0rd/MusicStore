using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Users.Repository
{
    public interface IUserRepository : IAddRepository<User>, IUpdateRepository<User>, IDeleteRepository<User>
    {
        Task<User?> GetByIdAsync( Guid id );

        Task<User?> FindAsync( Expression<Func<User, bool>> predicate );
    }
}
