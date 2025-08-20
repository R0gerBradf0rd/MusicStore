using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Repositories
{
    public interface ICategoryRepository : IAddRepository<Category>, IDeleteRepository<Category>
    {
        Task<Category?> GetByIdOrDefaultAsync( Guid id );

        Task<bool> ContainsAsync( Expression<Func<Category, bool>> predicate );
    }
}
