using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Repositories
{
    public interface IProductTypeRepository : IRepository<ProductType>
    {
        Task<ProductType?> GetByIdOrDefaultAsync( Guid id );
    }
}
