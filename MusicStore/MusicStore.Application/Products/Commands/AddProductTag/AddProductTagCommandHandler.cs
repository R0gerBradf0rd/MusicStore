using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Commands.AddProductTag
{
    public class AddProductTagCommandHandler : ICommandHandler<AddProductTagCommand, Result<ProductTag>>
    {
        private readonly IProductTagRepository _productTagRepository;

        private readonly IProductRepository _productRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IAsyncValidator<AddProductTagCommand> _asyncValidator;

        public AddProductTagCommandHandler(
            IProductTagRepository productTagRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<AddProductTagCommand> asyncValidator )
        {
            _productTagRepository = productTagRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result<ProductTag>> Handle( AddProductTagCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<ProductTag>.Failure( validationResult.Error );
            }
            try
            {
                Product product = await _productRepository.GetByIdOrDefaultAsync( request.ProductId );
                ProductTag productTag = new ProductTag( request.TagId, request.ProductId );
                product.AddTag( productTag );
                _productTagRepository.Add( productTag );
                await _unitOfWork.CommitAsync();
                return Result<ProductTag>.Success( productTag );
            }
            catch ( Exception ex )
            {
                return Result<ProductTag>.Failure( ex.Message );
            }
        }
    }
}
