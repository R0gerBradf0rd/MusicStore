using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Repositories
{
    public interface IProductRepository : IAddRepository<Product>, IDeleteRepository<Product>
    {
        Task<Product?> GetByIdOrDefaultAsync( Guid id );

        Task<bool> ContainsAsync( Expression<Func<Product, bool>> predicate );
    }
}
