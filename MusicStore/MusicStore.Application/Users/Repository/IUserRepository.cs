using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Users.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByIdAsync( Guid id );

        Task<User?> FindAsync( Expression<Func<User, bool>> predicate );

        Task<IEnumerable<User>> GetAllAsync();
    }
}
