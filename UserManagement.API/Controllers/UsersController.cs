using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Features.Users.Commands.CreateUser;
using UserManagement.Application.Features.Users.Commands.DeleteUser;
using UserManagement.Application.Features.Users.Commands.UpdateUser;
using UserManagement.Application.Features.Users.Queries.GetAllUsers;
using UserManagement.Application.Features.Users.Queries.GetUserById;

namespace UserManagement.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);
            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return NotFound(result.Errors);

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateUserRequest request)
        {
            var command = new CreateUserCommand(request);
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateUserRequest request)
        {
            request.Id = id;

            var command = new UpdateUserCommand(request);
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return NotFound(result.Errors);

            return Ok(result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return NotFound(result.Errors);

            return NoContent();
        }
    }
}
