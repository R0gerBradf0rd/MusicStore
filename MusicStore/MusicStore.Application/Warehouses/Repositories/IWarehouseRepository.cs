using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Warehouses;

namespace MusicStore.Applicatuion.Warehouses.Repositories
{
    public interface IWarehouseRepository : IAddRepository<Warehouse>, IDeleteRepository<Warehouse>
    {
        Task<Warehouse?> GetByIdOrDefaultAsync( Guid id );

        Task<bool> ContainsAsync( Expression<Func<Warehouse, bool>> predicate );
    }
}
