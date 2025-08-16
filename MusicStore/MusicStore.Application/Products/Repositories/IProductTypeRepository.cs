using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Repositories
{
    public interface IProductTypeRepository : IAddRepository<ProductType>, IDeleteRepository<ProductType>
    {
        Task<ProductType?> GetByIdOrDefaultAsync( Guid id );

        Task<bool> ContainsAsync( Expression<Func<ProductType, bool>> predicate );
    }
}
