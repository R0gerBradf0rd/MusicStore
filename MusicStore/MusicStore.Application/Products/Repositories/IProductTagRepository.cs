using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Repositories
{
    public interface IProductTagRepository : IAddRepository<ProductTag>, IDeleteRepository<ProductTag>
    {
        Task<bool> ContainsAsync( Expression<Func<ProductTag, bool>> predicate );

        Task<ProductTag> FindeAsync( Expression<Func<ProductTag, bool>> predicate );
    }
}
