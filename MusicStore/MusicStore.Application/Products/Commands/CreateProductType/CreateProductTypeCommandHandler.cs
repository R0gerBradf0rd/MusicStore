using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Commands.CreateProductType
{
    public class CreateProductTypeCommandHandler : ICommandHandler<CreateProductTypeCommand, Result<Guid>>
    {
        private readonly IProductTypeRepository _productTypeRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IAsyncValidator<CreateProductTypeCommand> _asyncValidator;

        public CreateProductTypeCommandHandler(
            IProductTypeRepository productTypeRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<CreateProductTypeCommand> asyncValidator )
        {
            _productTypeRepository = productTypeRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result<Guid>> Handle( CreateProductTypeCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<Guid>.Failure( validationResult.Error );
            }
            try
            {
                ProductType productType = new ProductType( request.Name, request.CategoryId );
                _productTypeRepository.Add( productType );
                await _unitOfWork.CommitAsync();
                return Result<Guid>.Success( productType.Id );
            }
            catch ( Exception ex )
            {
                return Result<Guid>.Failure( ex.Message );
            }
        }
    }
}
