using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> GetByIdOrDefaultAsync( Guid id );
    }
}
