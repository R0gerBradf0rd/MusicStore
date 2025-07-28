using MediatR;
using MusicStore.Application.Commands;
using MusicStore.Application.Interfaces;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Handlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Guid>
    {
        private readonly IRepository<User> _repository;

        public CreateUserCommandHandler( IRepository<User> repository )
        {
            _repository = repository;
        }

        public async Task<Guid> Handle( CreateUserCommand request, CancellationToken cancellationToken )
        {
            User user = new( request.Name, request.Email, request.Role );
            await _repository.AddAsync( user );
            return user.Id;
        }
    }
}
