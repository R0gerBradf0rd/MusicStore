using Microsoft.EntityFrameworkCore;
using MusicStore.Application.Products.Repositories;
using MusicStore.Domain.Entities.Products;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Repositories.Products
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductTypeRepository( AppDbContext dbContext )
            : base( dbContext )
        {
            _dbContext = dbContext;
        }

        public Task<ProductType?> GetByIdOrDefaultAsync( Guid id )
        {
            return Entities.FirstOrDefaultAsync( pt => pt.Id == id );
        }
    }
}
