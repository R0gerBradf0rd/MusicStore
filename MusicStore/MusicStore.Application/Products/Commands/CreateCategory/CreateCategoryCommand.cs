using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Products.Commands.CreateCategory
{
    public class CreateCategoryCommand : ICommand<Result<Guid>>
    {
        public string Name { get; }

        public CreateCategoryCommand( string name )
        {
            Name = name;
        }
    }
}
