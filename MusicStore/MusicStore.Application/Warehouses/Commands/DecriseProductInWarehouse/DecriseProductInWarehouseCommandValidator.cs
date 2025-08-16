using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Warehouses.Repositories;
using MusicStore.Domain.Entities.Warehouses;

namespace MusicStore.Application.Warehouses.Commands.DecriseProductInWarehouse
{
    public class DecriseProductInWarehouseCommandValidator : IAsyncValidator<DecriseProductInWarehouseCommand>
    {
        private readonly IProductWarehouseRepository _productWarehouseRepository;

        public DecriseProductInWarehouseCommandValidator( IProductWarehouseRepository productWarehouseRepository )
        {
            _productWarehouseRepository = productWarehouseRepository;
        }
        public async Task<Result> ValidateAsync( DecriseProductInWarehouseCommand request )
        {
            if ( request.ProductId == Guid.Empty )
            {
                return Result.Failure( "Id продукта не может быть пустым!" );
            }
            if ( request.WarehouseId == Guid.Empty )
            {
                return Result.Failure( "Id склада не может быть пустым!" );
            }
            if ( request.WarehouseProductQuantity < 1 )
            {
                return Result.Failure( "Количество товара не может быть меньше 1!" );
            }

            bool isWarehouseProductExist = await _productWarehouseRepository.ContainsAsync( pw => pw.WarehouseId == request.WarehouseId && pw.ProductId == request.ProductId );

            if ( !isWarehouseProductExist )
            {
                return Result.Failure( "Такого продукта нет на этом складе!" );
            }

            ProductWarehouse productWarehouse = await _productWarehouseRepository.FindeAsync( pw => pw.WarehouseId == request.WarehouseId && pw.ProductId == request.ProductId );

            if ( productWarehouse.Quantity - request.WarehouseProductQuantity < 1 )
            {
                return Result.Failure( "Количество товара недостаточно для выполнения операции!" );
            }

            return Result.Success();
        }
    }
}
