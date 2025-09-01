using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Application.Results;
using MusicStore.Application.Users.Dtos;
using MusicStore.Application.Users.Queries.GetUser;
using MusicStore.Presentation.Contracts.Users;
using MusicStore.Presentation.Mappers.UserMappingExtensions;
using MusicStore.Presentation.UserMappingExtensions;

namespace MusicStore.Presentation.Controllers
{
    [ApiController]
    [Route( "api/[controller]" )]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController( IMediator mediator )
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser( [FromBody] CreateUserRequest request )
        {
            Result<Guid> createUserResult = await _mediator.Send( request.ToCommand() );

            if ( createUserResult.IsError )
            {
                return BadRequest( createUserResult.Error );
            }

            return Ok( createUserResult.ToResponse() );
        }

        [HttpGet( "{id:guid}" )]
        public async Task<ActionResult> GetUserById( Guid id )
        {
            Result<UserDto> getUserResult = await _mediator.Send( new GetUserQuery( id ) );

            if ( getUserResult.IsError )
            {
                return BadRequest( getUserResult.Error );
            }

            return Ok( getUserResult.ToResponse() );
        }
    }
}
