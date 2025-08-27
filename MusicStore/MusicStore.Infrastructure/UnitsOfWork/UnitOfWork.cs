using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Reviews.Repositories;
using MusicStore.Application.Users.Repositories;
using MusicStore.Application.Warehouses.Repositories;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public ICartItemRepository CartItemRepository { get; }

        public ICartRepository CartRepository { get; }

        public IOrderItemRepository OrderItemRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IProductTagRepository ProductTagRepository { get; }

        public IProductTypeRepository ProductTypeRepository { get; }

        public ITagRepository TagRepository { get; }

        public IReviewRepository ReviewRepository { get; }

        public IUserRepository UserRepository { get; }

        public IProductWarehouseRepository ProductWarehouseRepository { get; }

        public IWarehouseRepository WarehouseRepository { get; }

        public UnitOfWork(
            AppDbContext dbContext,
            ICartItemRepository cartItemRepository,
            ICartRepository cartRepository,
            IOrderItemRepository orderItemRepository,
            IOrderRepository orderRepository,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            IProductTagRepository productTagRepository,
            IProductTypeRepository productTypeRepository,
            ITagRepository tagRepository,
            IReviewRepository reviewRepository,
            IUserRepository userRepository,
            IProductWarehouseRepository productWarehouseRepository,
            IWarehouseRepository warehouseRepository )
        {
            _dbContext = dbContext;
            CartItemRepository = cartItemRepository;
            CartRepository = cartRepository;
            OrderItemRepository = orderItemRepository;
            OrderRepository = orderRepository;
            CategoryRepository = categoryRepository;
            ProductRepository = productRepository;
            ProductTagRepository = productTagRepository;
            ProductTypeRepository = productTypeRepository;
            TagRepository = tagRepository;
            ReviewRepository = reviewRepository;
            UserRepository = userRepository;
            ProductWarehouseRepository = productWarehouseRepository;
            WarehouseRepository = warehouseRepository;
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
