namespace UserManagement.Application.Features.Auth.Commands.Register
{
    public class RegisterResponse
    {
        public RegisterDto registerDto { get; set; }
    }
    public class RegisterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

