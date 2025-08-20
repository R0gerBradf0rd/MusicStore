using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Warehouses.Repositories;
using MusicStore.Domain.Entities.Warehouses;

namespace MusicStore.Application.Warehouses.Commands.AddProductToWarehouse
{
    public class AddProductToWarehouseCommandHandler : ICommandHandler<AddProductToWarehouseCommand, Result<ProductWarehouse>>
    {
        private readonly IProductWarehouseRepository _productWarehouseRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<AddProductToWarehouseCommand> _addProductToWarehouseCommandValidator;

        public AddProductToWarehouseCommandHandler(
            IProductWarehouseRepository productWarehouseRepository,
            IWarehouseRepository warehouseRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<AddProductToWarehouseCommand> addProductToWarehouseCommandValidator )
        {
            _productWarehouseRepository = productWarehouseRepository;
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
            _addProductToWarehouseCommandValidator = addProductToWarehouseCommandValidator;
        }

        public async Task<Result<ProductWarehouse>> Handle( AddProductToWarehouseCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _addProductToWarehouseCommandValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<ProductWarehouse>.Failure( validationResult.Error );
            }
            try
            {
                Warehouse warehouse = await _warehouseRepository.GetByIdOrDefaultAsync( request.WarehouseId );
                ProductWarehouse productWarehouse = new ProductWarehouse( request.ProductId, request.WarehouseId, request.WarehouseProductQuantity );

                warehouse.AddProductToWarehouse( productWarehouse );
                _productWarehouseRepository.Add( productWarehouse );
                await _unitOfWork.CommitAsync();

                return Result<ProductWarehouse>.Success( productWarehouse );
            }
            catch ( Exception ex )
            {
                return Result<ProductWarehouse>.Failure( ex.Message );
            }
        }
    }
}
