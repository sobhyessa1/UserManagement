using UserManagement.Application.Features.Users.Commands.CreateUser;

namespace UserManagement.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserResponse
    {
        public UpdateUserDTO User { get; set; }
    }

    public class UpdateUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
