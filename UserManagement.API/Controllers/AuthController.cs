using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Features.Auth.Commands.Login;
using UserManagement.Application.Features.Auth.Commands.Register;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequest request)
        {
            var command = new RegisterCommand(request);
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            var command = new LoginCommand(request);
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return Unauthorized(result.Errors);

            return Ok(result.Value);
        }

    }
}
