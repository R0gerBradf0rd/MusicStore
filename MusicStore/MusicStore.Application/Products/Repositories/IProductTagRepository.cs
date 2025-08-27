using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Repositories
{
    public interface IProductTagRepository : IRepository<ProductTag>
    {
        Task<bool> ContainsAsync( Expression<Func<ProductTag, bool>> predicate );

        Task<ProductTag?> FindAsync( Expression<Func<ProductTag, bool>> predicate );
    }
}
