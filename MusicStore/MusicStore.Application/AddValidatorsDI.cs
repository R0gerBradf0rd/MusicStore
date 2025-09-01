using Microsoft.Extensions.DependencyInjection;
using MusicStore.Application.Carts.Commands.AddCartItem;
using MusicStore.Application.Carts.Commands.RemoveCartItem;
using MusicStore.Application.Carts.Commands.SetCartItemQuantity;
using MusicStore.Application.Carts.Commands.SetCartItemSelectionStatus;
using MusicStore.Application.Carts.Queries.GetCart;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Commands.CreateOrder;
using MusicStore.Application.Orders.Commands.SetStatusToArrived;
using MusicStore.Application.Orders.Commands.SetStatusToEndOfAssembly;
using MusicStore.Application.Orders.Commands.SetStatusToShipping;
using MusicStore.Application.Orders.Commands.SetStatusToStartAssembly;
using MusicStore.Application.Orders.Queries.GetOrder;
using MusicStore.Application.Products.Commands.AddProductTag;
using MusicStore.Application.Products.Commands.CreateCategory;
using MusicStore.Application.Products.Commands.CreateProduct;
using MusicStore.Application.Products.Commands.CreateProductType;
using MusicStore.Application.Products.Commands.CreateTag;
using MusicStore.Application.Products.Commands.RemoveProductTag;
using MusicStore.Application.Products.Queries.GetProduct;
using MusicStore.Application.Reviews.Commands.CreateReview;
using MusicStore.Application.Reviews.Commands.DeleteReview;
using MusicStore.Application.Reviews.Queries.GetReview;
using MusicStore.Application.Users.Commands.CreateUser;
using MusicStore.Application.Users.Queries.GetUser;
using MusicStore.Application.Warehouses.Commands.AddProductToWarehouse;
using MusicStore.Application.Warehouses.Commands.CreateWarehouse;

namespace MusicStore.Application
{
    public static class AddValidatorsDI
    {
        public static IServiceCollection AddValidators( this IServiceCollection services )
        {
            services.AddScoped<IAsyncValidator<CreateUserCommand>, CreateUserCommandValidator>();
            services.AddScoped<IAsyncValidator<GetUserQuery>, GetUserQueryValidator>();

            services.AddScoped<IAsyncValidator<CreateWarehouseCommand>, CreateWarehouseCommandValidator>();
            services.AddScoped<IAsyncValidator<AddProductToWarehouseCommand>, AddProductToWarehouseCommandValidator>();

            services.AddScoped<IValidator<CreateReviewCommand>, CreateReviewCommandValidator>();
            services.AddScoped<IAsyncValidator<DeleteReviewCommand>, DeleteReviewCommandValidator>();
            services.AddScoped<IAsyncValidator<GetReviewQuery>, GetReviewQueryValidator>();

            services.AddScoped<IAsyncValidator<AddProductTagCommand>, AddProductTagCommandValidator>();
            services.AddScoped<IAsyncValidator<CreateCategoryCommand>, CreateCategoryCommandValidator>();
            services.AddScoped<IAsyncValidator<CreateProductCommand>, CreateProductCommandValidator>();
            services.AddScoped<IAsyncValidator<CreateProductTypeCommand>, CreateProductTypeCommandValidator>();
            services.AddScoped<IAsyncValidator<CreateTagCommand>, CreateTagCommandValidator>();
            services.AddScoped<IAsyncValidator<RemoveProductTagCommand>, RemoveProductTagCommandValidator>();
            services.AddScoped<IAsyncValidator<GetProductQuery>, GetProductQueryValidator>();

            services.AddScoped<IAsyncValidator<CreateOrderCommand>, CreateOrderCommandValidator>();
            services.AddScoped<IAsyncValidator<SetStatusToArrivedCommand>, SetStatusToArrivedCommandValidator>();
            services.AddScoped<IAsyncValidator<SetStatusToEndOfAssemblyCommand>, SetStatusToEndOfAssemblyCommandValidator>();
            services.AddScoped<IAsyncValidator<SetStatusToShippingCommand>, SetStatusToShippingCommandValidator>();
            services.AddScoped<IAsyncValidator<SetStatusToStartAssemblyCommand>, SetStatusToStartAssemblyCommandValidator>();
            services.AddScoped<IAsyncValidator<GetOrderQuery>, GetOrderQueryValidator>();

            services.AddScoped<IAsyncValidator<AddCartItemToCartCommand>, AddCartItemToCartCommandValidator>();
            services.AddScoped<IAsyncValidator<RemoveCartItemCommand>, RemoveCartItemCommandValidator>();
            services.AddScoped<IAsyncValidator<SetCartItemQuantityCommand>, SetCartItemQuantityCommandValidator>();
            services.AddScoped<IAsyncValidator<SetCartItemSelectionStatusCommand>, SetCartItemSelectionStatusCommandValidator>();
            services.AddScoped<IAsyncValidator<GetCartQuery>, GetCartQueryValidator>();

            return services;
        }
    }
}
