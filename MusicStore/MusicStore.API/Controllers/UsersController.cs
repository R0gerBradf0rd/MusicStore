using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Application.Results;
using MusicStore.Application.Users.Commands.CreateUser;
using MusicStore.Application.Users.Dtos;
using MusicStore.Application.Users.Queries.GetUser;

namespace MusicStore.API.Controllers
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
        public async Task<IActionResult> CreateUser( [FromBody] CreateUserCommand command )
        {
            Result<Guid> result = await _mediator.Send( command );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok( result.Value );
        }

        [HttpGet( "{id}" )]
        public async Task<ActionResult> GetUserById( Guid id )
        {
            Result<UserDto> user = await _mediator.Send( new GetUserQuery( id ) );

            if ( user.IsError )
            {
                return BadRequest( user.Error );
            }

            return Ok( user.Value );
        }
    }
}
