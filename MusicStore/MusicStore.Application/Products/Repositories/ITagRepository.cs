using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Repositories
{
    public interface ITagRepository : IAddRepository<Tag>, IDeleteRepository<Tag>
    {
        Task<Tag?> GetByIdOrDefaultAsync( Guid id );

        Task<bool> ContainsAsync( Expression<Func<Tag, bool>> predicate );
    }
}
