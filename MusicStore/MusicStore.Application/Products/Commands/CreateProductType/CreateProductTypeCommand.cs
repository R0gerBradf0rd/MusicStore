using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Products.Commands.CreateProductType
{
    public class CreateProductTypeCommand : ICommand<Result<Guid>>
    {
        public string Name { get; }
        public Guid CategoryId { get; }

        public CreateProductTypeCommand( string name, Guid categoryId )
        {
            Name = name;
            CategoryId = categoryId;
        }
    }
}
