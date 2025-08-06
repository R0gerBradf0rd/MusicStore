using MusicStore.Application.Interfaces.Query;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Dtos;
using MusicStore.Application.Products.Mappers;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, Result<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        private readonly IAsyncValidator<GetProductQuery> _asyncValidator;

        public GetProductQueryHandler(
            IProductRepository productRepository,
            IAsyncValidator<GetProductQuery> asyncValidator )
        {
            _productRepository = productRepository;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result<ProductDto>> Handle( GetProductQuery request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<ProductDto>.Failure( validationResult.Error );
            }
            try
            {
                Product product = await _productRepository.GetByIdOrDefaultAsync( request.Id );

                return Result<ProductDto>.Success( product.ToDto() );
            }
            catch ( Exception ex )
            {
                return Result<ProductDto>.Failure( ex.Message );
            }
        }
    }
}
