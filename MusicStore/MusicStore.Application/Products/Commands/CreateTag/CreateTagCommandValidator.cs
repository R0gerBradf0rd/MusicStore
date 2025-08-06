using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;

namespace MusicStore.Application.Products.Commands.CreateTag
{
    public class CreateTagCommandValidator : IAsyncValidator<CreateTagCommand>
    {
        private readonly ITagRepository _tagRepository;

        public CreateTagCommandValidator( ITagRepository tagRepository )
        {
            _tagRepository = tagRepository;
        }

        public async Task<Result> ValidateAsync( CreateTagCommand request )
        {
            if ( string.IsNullOrWhiteSpace( request.Value ) )
            {
                return Result.Failure( "Значение тега не может быть пустым!" );
            }

            bool isTagAlreadyExist = await _tagRepository.ContainsAsync( t => t.Value == request.Value );

            if ( isTagAlreadyExist )
            {
                return Result.Failure( "Данный тег уже существует!" );
            }

            return Result.Success();
        }
    }
}
