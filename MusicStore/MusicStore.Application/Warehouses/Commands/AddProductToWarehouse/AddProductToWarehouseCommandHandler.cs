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
        private readonly IProductWarehouseRepository _repository;
        private readonly IWarehosueRepository _warehosueRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<AddProductToWarehouseCommand> _asyncValidator;

        public AddProductToWarehouseCommandHandler(
            IProductWarehouseRepository repository,
            IWarehosueRepository warehosueRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<AddProductToWarehouseCommand> asyncValidator )
        {
            _repository = repository;
            _warehosueRepository = warehosueRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result<ProductWarehouse>> Handle( AddProductToWarehouseCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<ProductWarehouse>.Failure( validationResult.Error );
            }
            try
            {
                Warehouse warehouse = await _warehosueRepository.GetByIdOrDefaultAsync( request.WarehouseId );
                ProductWarehouse productWarehouse = new ProductWarehouse( request.ProductId, request.WarehouseId, request.WarehouseProductQuantity );

                warehouse.AddProductToWarehouse( productWarehouse );
                _repository.Add( productWarehouse );
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
