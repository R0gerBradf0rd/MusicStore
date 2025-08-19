using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Result<Guid>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<CreateProductCommand> _createProductCommandValidator;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<CreateProductCommand> asyncValidator )
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _createProductCommandValidator = asyncValidator;
        }

        public async Task<Result<Guid>> Handle( CreateProductCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _createProductCommandValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<Guid>.Failure( validationResult.Error );
            }
            try
            {
                Product product = new Product
                (
                    request.Name,
                    request.Description,
                    request.Price,
                    request.PriceCurrencyCode,
                    request.ImageURL,
                    request.ProductTypeId,
                    request.ProductTags
                );

                _productRepository.Add( product );
                await _unitOfWork.CommitAsync();

                return Result<Guid>.Success( product.Id );
            }
            catch ( Exception ex )
            {
                return Result<Guid>.Failure( ex.Message );
            }
        }
    }
}
