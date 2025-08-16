using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Commands.AddProductTag;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;

namespace MusicStore.Application.Products.Commands.RemoveProductTag
{
    public class RemoveProductTagCommandValidator : IAsyncValidator<RemoveProductTagCommand>
    {
        private readonly IProductRepository _productRepository;

        private readonly ITagRepository _tagRepository;

        private readonly IProductTagRepository _productTagRepository;

        public RemoveProductTagCommandValidator(
            IProductRepository productRepository,
            ITagRepository tagRepository,
            IProductTagRepository productTagRepository )
        {
            _productRepository = productRepository;
            _tagRepository = tagRepository;
            _productTagRepository = productTagRepository;
        }

        public async Task<Result> ValidateAsync( RemoveProductTagCommand request )
        {
            if ( request.ProductId == Guid.Empty )
            {
                return Result.Failure( "Id продукта не может быть пустым!" );
            }
            if ( request.TagId == Guid.Empty )
            {
                return Result.Failure( "Id тега не может быть пустым!" );
            }

            bool isProductExist = await _productRepository.ContainsAsync( p => p.Id == request.ProductId );
            bool isTagExist = await _tagRepository.ContainsAsync( t => t.Id == request.TagId );

            if ( !isProductExist )
            {
                return Result.Failure( "Данного продутка несуществует!" );
            }
            if ( !isTagExist )
            {
                return Result.Failure( "Данного тега несуществует!" );
            }

            bool isProductTagAlreadyExist = await _productTagRepository.ContainsAsync( pt => pt.TagId == request.TagId && pt.ProductId == request.ProductId );

            if ( !isProductTagAlreadyExist )
            {
                return Result.Failure( "Данного тега нет у данного продукта!" );
            }

            return Result.Success();
        }
    }
}
