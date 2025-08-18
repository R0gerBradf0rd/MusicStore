using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Mappers;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Application.Users.Repositories;
using MusicStore.Application.Warehouses.Repositories;
using MusicStore.Domain.Entities.Carts;
using MusicStore.Domain.Entities.Orders;
using MusicStore.Domain.Entities.Warehouses;
using MusicStore.Domain.Validators;

namespace MusicStore.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : IAsyncValidator<CreateOrderCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductWarehouseRepository _productWarehouseRepository;

        public CreateOrderCommandValidator(
            IUserRepository userRepository,
            ICartRepository cartRepository,
            IProductWarehouseRepository productWarehouseRepository )
        {
            _userRepository = userRepository;
            _cartRepository = cartRepository;
            _productWarehouseRepository = productWarehouseRepository;
        }

        public async Task<Result> ValidateAsync( CreateOrderCommand request )
        {
            if ( request.UserId == Guid.Empty )
            {
                return Result.Failure( "Id пользователя не может быть пустым!" );
            }
            if ( request.CartId == Guid.Empty )
            {
                return Result.Failure( "Id пользователя не может быть пустым!" );
            }
            if ( string.IsNullOrWhiteSpace( request.ShippingAddress ) )
            {
                return Result.Failure( "Адрес доставки не может быть пустым!" );
            }
            if ( string.IsNullOrWhiteSpace( request.CurrencyCode ) )
            {
                return Result.Failure( "Адрес доставки не может быть пустым!" );
            }
            if ( !CurrencyCodeValidator.IsCurrencyCodeValid( request.CurrencyCode ) )
            {
                return Result.Failure( "Данного кода валюты нет в списке доступных кодов!" );
            }

            bool isUserExist = await _userRepository.ContainsAsync( u => u.Id == request.UserId );

            if ( !isUserExist )
            {
                return Result.Failure( "Данного пользователя несуществует!" );
            }

            bool isCartExist = await _cartRepository.ContainsAsync( c => c.Id == request.CartId );

            if ( !isCartExist )
            {
                return Result.Failure( "Данной корзины несуществует!" );
            }

            Cart cart = await _cartRepository.GetByIdOrDefaultAsync( request.CartId );

            if ( cart.UserId != request.UserId )
            {
                return Result.Failure( "Данная корзина не принадлежит данному пользователю!" );
            }

            List<CartItem> cartItems = cart.CartItems.ToList();

            foreach ( CartItem cartItem in cartItems )
            {
                ProductWarehouse? productWarehouse = await _productWarehouseRepository.FindeAsync( pw => pw.ProductId == cartItem.ProductId );
                if ( productWarehouse == null )
                {
                    return Result.Failure( $"Товар {cartItem.Product.Name} отсутсвует на складе!" );
                }
                if ( productWarehouse.Quantity < cartItem.Quantity )
                {
                    return Result.Failure( "Недостаточно товара на складе!" );
                }
            }

            return Result.Success();
        }
    }
}
