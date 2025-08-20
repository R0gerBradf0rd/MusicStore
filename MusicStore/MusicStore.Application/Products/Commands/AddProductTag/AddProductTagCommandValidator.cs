using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;

namespace MusicStore.Application.Products.Commands.AddProductTag
{
    public class AddProductTagCommandValidator : IAsyncValidator<AddProductTagCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IProductTagRepository _productTagRepository;

        public AddProductTagCommandValidator(
            IProductRepository productRepository,
            ITagRepository tagRepository,
            IProductTagRepository productTagRepository )
        {
            _productRepository = productRepository;
            _tagRepository = tagRepository;
            _productTagRepository = productTagRepository;
        }

        public async Task<Result> ValidateAsync( AddProductTagCommand request )
        {
            if ( request.ProductId == Guid.Empty )
            {
                return Result.Failure( "Id продукта не может быть пустым!" );
            }
            if ( request.TagId == Guid.Empty )
            {
                return Result.Failure( "Id тега не может быть пустым!" );
            }

            bool isProductExists = await _productRepository.ContainsAsync( p => p.Id == request.ProductId );

            if ( !isProductExists )
            {
                return Result.Failure( "Данного продутка несуществует!" );
            }

            bool isTagExists = await _tagRepository.ContainsAsync( t => t.Id == request.TagId );

            if ( !isTagExists )
            {
                return Result.Failure( "Данного тега несуществует!" );
            }

            bool isProductTagAlreadyExist = await _productTagRepository.ContainsAsync( pt => pt.TagId == request.TagId && pt.ProductId == request.ProductId );

            if ( isProductTagAlreadyExist )
            {
                return Result.Failure( "Данный тег уже есть у данного продукта!" );
            }

            return Result.Success();
        }
    }
}
