using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;
using MusicStore.Application.Warehouses.Repositories;

namespace MusicStore.Application.Warehouses.Commands.DeleteProductFromWarehouse
{
    public class DeleteProductFromWarehouseCommandValidator : IAsyncValidator<DeleteProductFromWarehouseCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IWarehosueRepository _warehosueRepository;
        private readonly IProductWarehouseRepository _productWarehouseRepository;

        public DeleteProductFromWarehouseCommandValidator(
            IProductRepository productRepository,
            IWarehosueRepository warehosueRepository,
            IProductWarehouseRepository productWarehouseRepository )
        {
            _productRepository = productRepository;
            _warehosueRepository = warehosueRepository;
            _productWarehouseRepository = productWarehouseRepository;
        }

        public async Task<Result> ValidateAsync( DeleteProductFromWarehouseCommand request )
        {
            if ( request.ProductId == Guid.Empty )
            {
                return Result.Failure( "Id не может быть пустым!" );
            }

            bool isProductExist = await _productRepository.ContainsAsync( p => p.Id == request.ProductId );
            bool isWarehouseExist = await _warehosueRepository.ContainsAsync( w => w.Id == request.WarehouseId );

            if ( !isProductExist )
            {
                return Result.Failure( "Данного продукта несуществует!" );
            }
            if ( !isWarehouseExist )
            {
                return Result.Failure( "Данного склада несуществует!" );
            }

            bool isProductInWarehouse = await _productWarehouseRepository.ContainsAsync( p => p.WarehouseId == request.WarehouseId && p.ProductId == request.ProductId );

            if ( !isProductInWarehouse )
            {
                return Result.Failure( "Данный продук не содержится на данном складе!" );
            }

            return Result.Success();
        }
    }
}
