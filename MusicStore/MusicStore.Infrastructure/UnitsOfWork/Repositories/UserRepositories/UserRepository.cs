using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Users.Repositories;
using MusicStore.Domain.Entities.Users;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.UnitsOfWork.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository( AppDbContext appDbContext )
        {
            _appDbContext = appDbContext;
        }
        public void Add( User entity )
        {
            _appDbContext.Users.Add( entity );
        }

        public async Task<bool> ContainsAsync( Expression<Func<User, bool>> predicate )
        {
            return await _appDbContext.Users.AnyAsync<User>( predicate );
        }

        public void Delete( User entity )
        {
            _appDbContext.Users.Remove( entity );
        }

        public async Task<User?> GetByIdOrDefaultAsync( Guid id )
        {
            return await _appDbContext.Users.FirstOrDefaultAsync( u => u.Id == id );
        }
    }
}
