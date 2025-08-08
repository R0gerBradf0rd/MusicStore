using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Warehouses.Repositories;
using MusicStore.Domain.Entities.Warehouses;

namespace MusicStore.Application.Warehouses.Commands.TakeProductFromWarehouse
{
    public class TakeProductFromWarehouseCommandHandler : ICommandHandler<TakeProductFromWarehouseCommand, Result<ProductWarehouse>>
    {
        private readonly IProductWarehouseRepository _repository;
        private readonly IWarehosueRepository _warehosueRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<TakeProductFromWarehouseCommand> _asyncValidator;

        public TakeProductFromWarehouseCommandHandler(
            IProductWarehouseRepository repository,
            IWarehosueRepository warehosueRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<TakeProductFromWarehouseCommand> asyncValidator )
        {
            _repository = repository;
            _warehosueRepository = warehosueRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result<ProductWarehouse>> Handle( TakeProductFromWarehouseCommand request, CancellationToken cancellationToken )
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

                await _warehosueRepository.DeleteAsync( warehouse );
                await _repository.DeleteAsync( productWarehouse );
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
