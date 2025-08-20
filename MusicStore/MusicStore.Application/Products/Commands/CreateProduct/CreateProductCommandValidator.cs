using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;

namespace MusicStore.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : IAsyncValidator<CreateProductCommand>
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public CreateProductCommandValidator( IProductTypeRepository productTypeRepository )
        {
            _productTypeRepository = productTypeRepository;
        }

        public async Task<Result> ValidateAsync( CreateProductCommand request )
        {
            if ( string.IsNullOrWhiteSpace( request.Name ) )
            {
                return Result.Failure( "Название продукта не может быть пустым!" );
            }
            if ( string.IsNullOrWhiteSpace( request.PriceCurrencyCode ) )
            {
                return Result.Failure( "Код валюты не может быть пустым!" );
            }
            if ( string.IsNullOrWhiteSpace( request.ImageURL ) )
            {
                return Result.Failure( "URL картинки не может быть пустым!" );
            }
            if ( request.Price <= 0 )
            {
                return Result.Failure( "Цена должна быть больше нуля!" );
            }
            if ( request.ProductTypeId == Guid.Empty )
            {
                return Result.Failure( "Id типа продукта не может быть пустым!" );
            }

            bool isProductTypeExists = await _productTypeRepository.ContainsAsync( pt => pt.Id == request.ProductTypeId );

            if ( !isProductTypeExists )
            {
                return Result.Failure( "Данного типа продукта несуществует!" );
            }

            return Result.Success();
        }
    }
}
