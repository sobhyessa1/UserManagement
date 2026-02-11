namespace UserManagement.Application.Features.Auth.Commands.Login
{
    public class LoginResponse
    {
        public LoginResponseDto LoginDto { get; set; }
    }
    public class LoginResponseDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
