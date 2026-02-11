namespace UserManagement.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserResponse
    {
        public CreateUserDTO User { get; set; }
    }

    public class CreateUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
