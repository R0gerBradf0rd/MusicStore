using System.Linq.Expressions;
using MusicStore.Application.Interfaces.Repository;
using MusicStore.Domain.Entities.Warehouses;

namespace MusicStore.Application.Warehouses.Repositories
{
    public interface IProductWarehouseRepository : IRepository<ProductWarehouse>
    {
        Task<ProductWarehouse?> FindAsync( Expression<Func<ProductWarehouse, bool>> predicate );
    }
}
