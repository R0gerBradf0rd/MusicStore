using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Warehouses;

namespace MusicStore.Application.Warehouses.Repositories
{
    public interface IWarehouseRepository : IRepository<Warehouse>
    {
        Task<Warehouse?> GetByIdOrDefaultAsync( Guid id );
    }
}
