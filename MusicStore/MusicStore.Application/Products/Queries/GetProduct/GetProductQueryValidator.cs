using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;

namespace MusicStore.Application.Products.Queries.GetProduct
{
    public class GetProductQueryValidator : IAsyncValidator<GetProductQuery>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryValidator( IProductRepository productRepository )
        {
            _productRepository = productRepository;
        }

        public async Task<Result> ValidateAsync( GetProductQuery request )
        {
            if ( request.Id == Guid.Empty )
            {
                return Result.Failure( "Id не может быть пустым!" );
            }

            bool isProductExist = await _productRepository.ContainsAsync( p => p.Id == request.Id );

            if ( !isProductExist )
            {
                return Result.Failure( "Данного продукта несуществует!" );
            }

            return Result.Success();
        }
    }
}
