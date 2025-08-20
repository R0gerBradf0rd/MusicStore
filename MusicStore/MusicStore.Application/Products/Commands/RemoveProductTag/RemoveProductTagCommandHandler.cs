using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Commands.RemoveProductTag
{
    public class RemoveProductTagCommandHandler : ICommandHandler<RemoveProductTagCommand, Result<ProductTag>>
    {
        private readonly IProductTagRepository _productTagRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<RemoveProductTagCommand> _removeProductTagCommandValidator;

        public RemoveProductTagCommandHandler(
            IProductTagRepository productTagRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<RemoveProductTagCommand> removeProductTagCommandValidator )
        {
            _productTagRepository = productTagRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _removeProductTagCommandValidator = removeProductTagCommandValidator;
        }

        public async Task<Result<ProductTag>> Handle( RemoveProductTagCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _removeProductTagCommandValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<ProductTag>.Failure( validationResult.Error );
            }
            try
            {
                Product product = await _productRepository.GetByIdOrDefaultAsync( request.ProductId );
                ProductTag productTag = await _productTagRepository.FindAsync( pt => pt.TagId == request.TagId && pt.ProductId == request.ProductId );

                product.RemoveTag( productTag );
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
