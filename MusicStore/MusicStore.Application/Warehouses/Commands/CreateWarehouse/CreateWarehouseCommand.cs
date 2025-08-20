using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Warehouses.Commands.CreateWarehouse
{
    public class CreateWarehouseCommand : ICommand<Result<Guid>>
    {
        public string Address { get; }

        public CreateWarehouseCommand( string address )
        {
            Address = address;
        }
    }
}
