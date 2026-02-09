using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.DTOs;
using UserManagement.Application.Services;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<UserDto>> GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetById(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<UserDto> Create([FromBody] CreateUserDto dto)
        {
            if (dto == null)
            {
                return BadRequest("User data is required");
            }

            var createdUser = _userService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public ActionResult<UserDto> Update(int id, [FromBody] CreateUserDto dto)
        {
            if (dto == null)
            {
                return BadRequest("User data is required");
            }

            var updatedUser = _userService.Update(id, dto);

            if (updatedUser == null)
            {
                return NotFound("User not found");
            }

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            _userService.Delete(id);
            return NoContent();
        }
    }
}
