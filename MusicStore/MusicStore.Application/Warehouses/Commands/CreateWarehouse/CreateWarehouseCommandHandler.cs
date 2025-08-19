using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Warehouses.Repositories;
using MusicStore.Domain.Entities.Warehouses;

namespace MusicStore.Application.Warehouses.Commands.CreateWarehouse
{
    public class CreateWarehouseCommandHandler : ICommandHandler<CreateWarehouseCommand, Result<Guid>>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<CreateWarehouseCommand> _createWarehouseCommandValidator;

        public CreateWarehouseCommandHandler( IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork, IAsyncValidator<CreateWarehouseCommand> asyncValidator )
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
            _createWarehouseCommandValidator = asyncValidator;
        }

        public async Task<Result<Guid>> Handle( CreateWarehouseCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _createWarehouseCommandValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<Guid>.Failure( validationResult.Error );
            }
            try
            {
                Warehouse warehouse = new Warehouse( request.Address );

                _warehouseRepository.Add( warehouse );
                await _unitOfWork.CommitAsync();

                return Result<Guid>.Success( warehouse.Id );
            }
            catch ( Exception ex )
            {
                return Result<Guid>.Failure( ex.Message );
            }
        }
    }
}
