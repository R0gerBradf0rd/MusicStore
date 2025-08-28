using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected DbSet<TEntity> Entities { get; }

        public Repository( AppDbContext dbContext )
        {
            Entities = dbContext.Set<TEntity>();
        }

        public void Add( TEntity entity )
        {
            Entities.Add( entity );
        }

        public void Delete( TEntity entity )
        {
            Entities.Remove( entity );
        }

        public Task<bool> ContainsAsync( Expression<Func<TEntity, bool>> predicate )
        {
            return Entities.AnyAsync( predicate );
        }
    }
}
