using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Products.Commands.CreateTag
{
    public class CreateTagCommand : ICommand<Result<Guid>>
    {
        public string Value { get; }

        public CreateTagCommand( string value )
        {
            Value = value;
        }
    }
}
