﻿using MediatR;
using MusicStore.Application.Interfaces;
using MusicStore.Application.Queries;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IRepository<User> _repository;

        public GetUserByIdQueryHandler( IRepository<User> repository )
        {
            _repository = repository;
        }

        public async Task<User?> Handle( GetUserByIdQuery request, CancellationToken cancellationToken )
        {
            return await _repository.GetByIdAsync( request.Id );
        }
    }
}
