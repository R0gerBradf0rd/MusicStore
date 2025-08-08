using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : ICommand<Result<Guid>>
    {
        public Guid UserId { get; }

        public Guid CartId { get; }

        public string ShippingAddress { get; }

        public string CurrencyCode { get; }

        public CreateOrderCommand( Guid userId, Guid cartId, string shippingAddress, string currencyCode )
        {
            UserId = userId;
            CartId = cartId;
            ShippingAddress = shippingAddress;
            CurrencyCode = currencyCode;
        }
    }
}
