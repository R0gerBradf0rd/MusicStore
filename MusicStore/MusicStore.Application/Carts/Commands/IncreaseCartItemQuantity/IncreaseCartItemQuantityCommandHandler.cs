using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Carts.Commands.IncreaseCartItemQuantity
{
    public class IncreaseCartItemQuantityCommandHandler : ICommandHandler<IncreaseCartItemQuantityCommand, Result<string>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        private readonly ICartRepository _cartRepository;

        private readonly IProductRepository _productRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IAsyncValidator<IncreaseCartItemQuantityCommand> _asyncValidator;

        public IncreaseCartItemQuantityCommandHandler(
            ICartItemRepository cartItemRepository,
            ICartRepository cartRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<IncreaseCartItemQuantityCommand> asyncValidator )
        {
            _cartItemRepository = cartItemRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result<string>> Handle( IncreaseCartItemQuantityCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<string>.Failure( validationResult.Error );
            }
            try
            {
                CartItem cartItem = await _cartItemRepository.GetByIdOrDefaultAsync( request.Id );
                Product product = await _productRepository.GetByIdOrDefaultAsync( cartItem.ProductId );
                Cart cart = await _cartRepository.GetByIdOrDefaultAsync( cartItem.CartId );
                cartItem.IncreaseQuantityByOne();
                cartItem.CalculateCartItemPrice( product.Price );
                cart.CalculateTotalPrice();
                await _unitOfWork.CommitAsync();
                return Result<string>.Success( "Количество товара в корзине увеличено 1." );
            }
            catch ( Exception ex )
            {
                return Result<string>.Failure( ex.Message );
            }
        }
    }
}
