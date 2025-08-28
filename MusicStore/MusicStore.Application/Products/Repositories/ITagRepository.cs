using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<Tag?> GetByIdOrDefaultAsync( Guid id );
    }
}
