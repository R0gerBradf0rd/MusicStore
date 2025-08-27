using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Users.Repositories;
using MusicStore.Domain.Entities.Users;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Repositories.UserRepositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository( AppDbContext dbContext )
            : base( dbContext )
        {
            _dbContext = dbContext;
        }

        public Task<bool> ContainsAsync( Expression<Func<User, bool>> predicate )
        {
            return _dbContext.Users.AnyAsync( predicate );
        }

        public Task<User?> GetByIdOrDefaultAsync( Guid id )
        {
            return _dbContext.Users.FirstOrDefaultAsync( u => u.Id == id );
        }
    }
}
