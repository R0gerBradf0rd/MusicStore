using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Carts.Commands.AddCartItem
{
    public class AddCartItemToCartCommandHandler : ICommandHandler<AddCartItemToCartCommand, Result<CartItem>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<AddCartItemToCartCommand> _asyncValidator;

        public AddCartItemToCartCommandHandler(
            ICartRepository cartRepository,
            ICartItemRepository cartItemRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<AddCartItemToCartCommand> validator )
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = validator;
        }

        public async Task<Result<CartItem>> Handle( AddCartItemToCartCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<CartItem>.Failure( validationResult.Error );
            }
            try
            {
                Cart? cart = await _cartRepository.GetByIdOrDefaultAsync( request.CartId );
                Product product = await _productRepository.GetByIdOrDefaultAsync( request.ProductId );
                CartItem cartItem = new CartItem( request.ProductId, request.CartId, product );

                cart.AddCartItem( cartItem );
                cart.UppdateTotalPrice();
                await _unitOfWork.CommitAsync();

                return Result<CartItem>.Success( cartItem );
            }
            catch ( Exception ex )
            {
                return Result<CartItem>.Failure( ex.Message );
            }
        }
    }
}
