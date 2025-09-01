using Microsoft.Extensions.DependencyInjection;
using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Reviews.Repositories;
using MusicStore.Application.Users.Repositories;
using MusicStore.Application.Warehouses.Repositories;
using MusicStore.Infrastructure.Repositories.Carts;
using MusicStore.Infrastructure.Repositories.Orders;
using MusicStore.Infrastructure.Repositories.Products;
using MusicStore.Infrastructure.Repositories.Reviews;
using MusicStore.Infrastructure.Repositories.UserRepositories;
using MusicStore.Infrastructure.Repositories.Warehouses;

namespace MusicStore.Infrastructure.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories( this IServiceCollection services )
        {
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IProductWarehouseRepository, ProductWarehouseRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IReviewRepository, ReviewRepository>();

            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IProductTagRepository, ProductTagRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<ICartRepository, CartRepository>();

            return services;
        }
    }
}
